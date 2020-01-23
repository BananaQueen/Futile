using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public Text optionsTextENG;    
    public Text musicTextENG;   
    public Text languageTextENG;    
    public Text onButtonTextENG;   
    public Text offButtonTextENG;
    public Text polskiButtonText;
    public Text englishButtonText;
    public Text BackButtonTextENG;

    public Text optionsTextPL;
    public Text musicTextPL;
    public Text languageTextPL;
    public Text onButtonTextPL;
    public Text offButtonTextPL;
    public Text backButtonTextPL;
    public MainMenu mainMenu;

    public void MusicButtonOff(WholeMenu menu)
    {
        menu.music.Stop();
    }
		
    public void MusicButtonOn(WholeMenu menu)
    {
        menu.music.Play();
    }

    public void EnglishButton(WholeMenu menu)
    {
        menu.languageVersion = 1;
        SetENGTexts();
        mainMenu.SetENGTexts();
    }

    public void PolskiButton(WholeMenu menu)
    {
        menu.languageVersion = 2;
        SetPLTexts();
        mainMenu.SetPLTexts();
    }

    public void SetPLTexts()
    {
        optionsTextPL.enabled = true;
        musicTextPL.enabled = true;
        languageTextPL.enabled = true;
        onButtonTextPL.enabled = true;
        offButtonTextPL.enabled = true;
        backButtonTextPL.enabled = true;

        optionsTextENG.enabled = false;
        musicTextENG.enabled = false;
        languageTextENG.enabled = false;
        onButtonTextENG.enabled = false;
        offButtonTextENG.enabled = false;
        BackButtonTextENG.enabled = false;
    }

    public void SetENGTexts()
    {
        optionsTextPL.enabled = false;
        musicTextPL.enabled = false;
        languageTextPL.enabled = false;
        onButtonTextPL.enabled = false;
        offButtonTextPL.enabled = false;
        backButtonTextPL.enabled = false;

        optionsTextENG.enabled = true;
        musicTextENG.enabled = true;
        languageTextENG.enabled = true;
        onButtonTextENG.enabled = true;
        offButtonTextENG.enabled = true;
        BackButtonTextENG.enabled = true;
    }
}