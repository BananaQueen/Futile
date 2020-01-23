using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    public string keyWord;
    public string keyWord2;
    public string keyWord3;

    public abstract void RespondToInput(GameController controller, string[] separatedInputWords);
}
