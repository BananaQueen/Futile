using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(menuName ="Futile/InputActions/Examine")]
public class Examine : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        controller.LogStringWithReturn(controller.TestVerbDictionaryWithNoun(controller.interactableObjects.examineDictionary, separatedInputWords[0], separatedInputWords[1]));
        controller.DisplayImageOfAnObject(controller.TestTextureDictionaryWithNoun(controller.interactableObjects.examineImageDictionary, separatedInputWords[1]));
    }
}
