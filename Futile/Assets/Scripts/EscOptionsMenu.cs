using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscOptionsMenu : MonoBehaviour
{

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
    public Text BackButtonTextPL;
    public WholeMenu audioSource;
    public Button onButton;
    public Button offButton;
    public EscMenu escMenu;

    void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("wholeCanvas").GetComponent<WholeMenu>();
        onButton = GameObject.FindGameObjectWithTag("onButton").GetComponent<Button>();
        onButton.onClick.AddListener(() => MusicButtonOn(audioSource));
        offButton = GameObject.FindGameObjectWithTag("offButton").GetComponent<Button>();
        offButton.onClick.AddListener(() => MusicButtonOff(audioSource));
    }

    public void MusicButtonOff(WholeMenu menu)
    {
        menu.music.Stop();
    }

    public void MusicButtonOn(WholeMenu menu)
    {
        menu.music.Play();
    }

    public void EnglishButton(Language language)
    {
        language.version = 1;
        SetENGTexts();
        escMenu.SetENGTexts();
    }

    public void PolskiButton(Language language)
    {
        language.version = 2;
        SetPLTexts();
        escMenu.SetPLTexts();
    }

    public void SetPLTexts()
    {
        optionsTextPL.enabled = true;
        musicTextPL.enabled = true;
        languageTextPL.enabled = true;
        onButtonTextPL.enabled = true;
        offButtonTextPL.enabled = true;
        BackButtonTextPL.enabled = true;

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
        BackButtonTextPL.enabled = false;

        optionsTextENG.enabled = true;
        musicTextENG.enabled = true;
        languageTextENG.enabled = true;
        onButtonTextENG.enabled = true;
        offButtonTextENG.enabled = true;
        BackButtonTextENG.enabled = true;
    }
}