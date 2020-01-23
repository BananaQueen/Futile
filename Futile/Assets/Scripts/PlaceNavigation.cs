using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceNavigation : MonoBehaviour {

    public Place currentPlace;

    Dictionary<string, Place> exitDictionary = new Dictionary<string, Place>();
    private GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInPlace()
    {
        for (int i = 0; i < currentPlace.exits.Length; i++)
        {
            exitDictionary.Add(currentPlace.exits[i].keystring, currentPlace.exits[i].valueRoom);
            controller.interactionDescriptionsInPlace.Add(currentPlace.exits[i].exitDescription);
        }
    }

    public void AttemptToChangePlaces(string directionNoun)
    {
        if(exitDictionary.ContainsKey(directionNoun))
        {
            currentPlace = exitDictionary[directionNoun];
            controller.LogStringWithReturn("Poszedłeś do " + directionNoun);
            controller.DisplayPlaceText();
        }
        else
        {
            controller.LogStringWithReturn("Stąd nie ma przejścia do " + directionNoun);
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
