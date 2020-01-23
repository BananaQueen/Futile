using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Futile/Place")]
public class Place : ScriptableObject
{
    [TextArea]
    public string description;
    public string placeName;
    public Exit[] exits;
    public InteractableObject[] interactableObjectsInPlace;
}


