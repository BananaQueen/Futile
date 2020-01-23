using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WholeMenu : MonoBehaviour {

    public int languageVersion;
    public OptionsMenu optionsMenu;
    public MainMenu mainMenu;
    public AudioSource music;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("wholeCanvas");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

private void Start()
    {
        languageVersion = 1;
        optionsMenu.SetENGTexts();
        mainMenu.SetENGTexts();
    }

    public int getVersion()
    {
        return languageVersion;
    }
}