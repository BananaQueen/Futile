using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Futile/InputActions/Go")]
public class Go : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {    
      controller.placeNavigation.AttemptToChangePlaces(separatedInputWords[1]); 
    }

}
