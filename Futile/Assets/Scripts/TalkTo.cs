using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Futile/InputActions/Talk To")]
public class TalkTo : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        controller.LogStringWithReturn(controller.TestVerbDictionaryWithNoun(controller.interactableObjects.talkDictionary, separatedInputWords[0], separatedInputWords[1]));
        controller.StartDialogue(controller.TestTalkDictionaryWithNoun(controller.interactableObjects.talkDialogDictionary, separatedInputWords[1]));
        //controller.DisplayImageOfAnObject(controller.TestTalkDictionaryWithNoun(controller.interactableObjects.talkDialogDictionary, separatedInputWords[1]));
    }
}
