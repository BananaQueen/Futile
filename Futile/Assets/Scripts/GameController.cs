using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VIDE_Data;

public class GameController : MonoBehaviour {

    public Text displayText;
    public InputAction[] inputActions;
    public RawImage displayImage;
    public Button continueButton;

    [HideInInspector] public PlaceNavigation placeNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInPlace = new List<string>();
    [HideInInspector] public InteractableItems interactableObjects;
    [HideInInspector] public Queue<string> mySentences = new Queue<string>();

    List<string> actionLog = new List<string>();

	void Awake ()
    {
        continueButton.enabled = false;
        displayImage.enabled = false;
        interactableObjects = GetComponent<InteractableItems>();
        placeNavigation = GetComponent<PlaceNavigation> ();
	}

    void Start()
    {
        DisplayPlaceText();
        DisplayLoggedText ();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("-------------------- \n", actionLog.ToArray());

        displayText.text = logAsText;
    }

    public void DisplayPlaceText()
    {
        ClearCollectionsForNewPlace();

        UnpackPlace();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInPlace.ToArray());

        //string combinedText = "<color=yellow>" + placeNavigation.currentPlace.description + "</color>" + "\n" + joinedInteractionDescriptions;

        string combinedText = placeNavigation.currentPlace.description + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn (combinedText);
    }

    private void UnpackPlace()
    {
        placeNavigation.UnpackExitsInPlace();
        PrepareObjectsToTakeOrExamineOrTalk(placeNavigation.currentPlace);
    }

    private void PrepareObjectsToTakeOrExamineOrTalk (Place currentPlace)
    {
        for (int i = 0; i < currentPlace.interactableObjectsInPlace.Length; i++)
        {
            string descriptionNotInInventory = interactableObjects.GetObjectsNotInInventory(currentPlace, i);
            if(descriptionNotInInventory !=null)
            {
                interactionDescriptionsInPlace.Add(descriptionNotInInventory);
            }

            InteractableObject interactableInPlace = currentPlace.interactableObjectsInPlace[i];

            for (int j = 0; j < interactableInPlace.interactions.Length; j++)
            {
                Interaction interaction = interactableInPlace.interactions[j];
                if(interaction.inputAction.keyWord == "examine")
                { 
                    interactableObjects.examineDictionary.Add(interactableInPlace.noun, interaction.textResponse);
                    interactableObjects.examineImageDictionary.Add(interactableInPlace.noun, interaction.textureResponse);
                }

                if (interaction.inputAction.keyWord == "take")
                {
                    interactableObjects.takeDictionary.Add(interactableInPlace.noun, interaction.textResponse);
                }

                if (interaction.inputAction.keyWord == "talkto")
                {
                    interactableObjects.talkDictionary.Add(interactableInPlace.noun, interaction.textResponse);
                    interactableObjects.talkDialogDictionary.Add(interactableInPlace.noun, interactableInPlace.sentences);
                }
            }
        }
    }

    public void DisplayImageOfAnObject(Texture textureOfObject)
    {
        
        displayImage.texture = textureOfObject;
        displayImage.enabled = true;
    }

    public Texture TestTextureDictionaryWithNoun(Dictionary<string, Texture> textureDictionary, string noun)
    {
        if (textureDictionary.ContainsKey(noun))
        {
            return textureDictionary[noun];
        }

        return null;
    }

    public string[] TestTalkDictionaryWithNoun(Dictionary<string, string[]> talkDictionary, string noun)
    {
        if (talkDictionary.ContainsKey(noun))
        {
            return talkDictionary[noun];
        }

        return null;
    }

    public string TestVerbDictionaryWithNoun(Dictionary<string, string> verbDictionary, string verb, string noun)
    {
        if(verbDictionary.ContainsKey(noun))
        {
            return verbDictionary[noun];
        }

        return "Nie możesz " + verb + " " + noun;
    }

    void ClearCollectionsForNewPlace()
    {
        interactableObjects.ClearCollections();
        interactionDescriptionsInPlace.Clear();
        placeNavigation.ClearExits();
        ClearDisplayImage();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
	
	void ClearDisplayImage()
    {
        displayImage.enabled = false;
	}

    public void StartDialogue(string[] sentences)
    {

        Debug.Log("Starting conversation with ");

        continueButton.enabled = true;

        mySentences.Clear();

        foreach (string sentence in sentences)
        {
            mySentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if(mySentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = mySentences.Dequeue();

        //tutaj wyświetlamy rozmowę w tym naszym displayText
        LogStringWithReturn(sentence);

        Debug.Log(sentence);
    }

    void EndDialogue()
    {
        string end = "Koniec rozmowy";

        LogStringWithReturn(end);

        continueButton.enabled = false;

        Debug.Log("End of Conversation");
    }
}
