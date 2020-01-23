using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class InteractableItems : MonoBehaviour
{
    public List<InteractableObject> usableItemList;

    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    public Dictionary<string, Texture> examineImageDictionary = new Dictionary<string, Texture>();
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> talkDictionary = new Dictionary<string, string>();
    public Dictionary<string, string[]> talkDialogDictionary = new Dictionary<string, string[]>();

    [HideInInspector] public List<string> nounsInPlace = new List<string>();

    private Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();
    private List<string> nounsInInventory = new List<string>();
    private GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public string GetObjectsNotInInventory(Place currentPlace, int i)
    {
        InteractableObject interactableInPlace = currentPlace.interactableObjectsInPlace[i];

        if(!nounsInInventory.Contains(interactableInPlace.noun))
        {
            nounsInPlace.Add(interactableInPlace.noun);
            return interactableInPlace.description;
        }

        return null;
    }

    public void AddActionResponsesToUseDictionary()
    {
        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            string noun = nounsInInventory[i];

            InteractableObject interactableObjectInInventory = GetInteractableObjectFromUsableList(noun);
            if (interactableObjectInInventory == null)
            {
                continue;
            }

            for (int j = 0; j < interactableObjectInInventory.interactions.Length; j++)
            {
                Interaction interaction = interactableObjectInInventory.interactions[j];

                if(interaction.actionResponse == null)
                {
                    continue;
                }

                if(!useDictionary.ContainsKey(noun))
                {
                    useDictionary.Add(noun, interaction.actionResponse);
                }
            }
        }
    }

    private InteractableObject GetInteractableObjectFromUsableList(string noun)
    {
        for (int i = 0; i < usableItemList.Count; i++)
        {
            if (usableItemList[i].noun == noun)
            {
                return usableItemList[i];
            }
        }

        return null;
    }

    public void DisplayInventory()
    {
        controller.LogStringWithReturn("Zaglądasz do swojego plecaka, wśrodku masz ");
        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            controller.LogStringWithReturn(nounsInInventory[i]);
        }
    }

    public void ClearCollections()
    {
        examineDictionary.Clear();
        examineImageDictionary.Clear();
        takeDictionary.Clear();
        nounsInPlace.Clear();
        talkDictionary.Clear();
        talkDialogDictionary.Clear();
    }

    public Dictionary<string, string> Take (string[] separatedInputWords)
    {
        string noun = separatedInputWords[1];

        if(nounsInPlace.Contains(noun))
        {
            nounsInInventory.Add(noun);
            AddActionResponsesToUseDictionary();
            nounsInPlace.Remove(noun);
            return takeDictionary;
        }
        else
        {
            controller.LogStringWithReturn("Tutaj nie ma " + noun + "do wzięcia.");
            return null; 
        }
    }

    //public Dictionary<string, string> TalkTo(string[] separatedInputWords)
    //{
    //    string NPC = separatedInputWords[1];

    //    if (nounsInPlace.Contains(NPC))
    //    {
    //       //tutaj musisz chyba rozpocząć rozmowę...

    //        return talkDictionary;
    //    }
    //    else
    //    {
    //        controller.LogStringWithReturn("Nie ma takiej osoby do rozmowy");
    //        return null;
    //    }
    //}

    public void UseItem(string[] separatedInputWords)
    {
        string nounToUse = separatedInputWords[1];

        if(nounsInInventory.Contains(nounToUse))
        {
            if(useDictionary.ContainsKey(nounToUse))
            {
                bool actionResult = useDictionary[nounToUse].DoActionResponse(controller);
                if(!actionResult)
                {
                    controller.LogStringWithReturn("Nic się nie stało...");
                }
            }
            else
            {
                controller.LogStringWithReturn("nie możesz użyć " + nounToUse);
            }
        }
        else
        {
            controller.LogStringWithReturn("ale nie ma " + nounToUse + "w twoim plecaku");
        }
    }

}
