using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Futile/InputActions/Take")]
public class Take : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        Dictionary<string, string> takeDictionary = controller.interactableObjects.Take(separatedInputWords);
        if (takeDictionary != null)
        {
            controller.LogStringWithReturn(controller.TestVerbDictionaryWithNoun(takeDictionary, separatedInputWords[0], separatedInputWords[1]));
        }
    }
}
