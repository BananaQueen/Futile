using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Language : MonoBehaviour {

    public WholeMenu lanVersion;
    public int version;
    public EscOptionsMenu escOptionsMenu;
    public EscMenu escMenu;
    
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("wholeCanvas");
        lanVersion = GameObject.FindGameObjectWithTag("wholeCanvas").GetComponent<WholeMenu>();
        version = lanVersion.getVersion();
        Debug.Log("version of language: " + version);
        
        if(version==1)
        {
            escMenu.SetENGTexts();
            escOptionsMenu.SetENGTexts();
        }
        else
        {
            escMenu.SetPLTexts();
            escOptionsMenu.SetPLTexts();
        }
    }
}
