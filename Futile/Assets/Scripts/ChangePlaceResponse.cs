using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Futile/ActionResponses/ChangePlace")]
public class ChangePlaceResponse : ActionResponse
{
    public Place placeToChangeTo;

    public override bool DoActionResponse(GameController controller)
    {
        if (controller.placeNavigation.currentPlace.placeName == requiredString)
        {
            controller.placeNavigation.currentPlace = placeToChangeTo;
            controller.DisplayPlaceText();
            return true;
        }

        return false;
    }
}
