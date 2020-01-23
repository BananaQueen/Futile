using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Futile/Interactable Object")]
public class InteractableObject : ScriptableObject
{
    public string noun = "name";
    [TextArea]
    public string description = "description in Place";
    public Interaction[] interactions;
    [TextArea]
    public string[] sentences;
    //public Dialogue dialogue;
}
 