using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour {

    public Text resumeButtonTextENG;
    public Text saveGameButtonTextENG;
    public Text optionsButtonTextENG;
    public Text quitButtonTextENG;
    public Text resumeButtonTextPL;
    public Text saveGameButtonTextPL;
    public Text optionsButtonTextPL;
    public Text quitButtonTextPL;
    public GameObject menu;

    public void ResumeGame()
    {
        menu.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SetPLTexts()
    {
        resumeButtonTextENG.enabled = false;
        saveGameButtonTextENG.enabled = false;
        optionsButtonTextENG.enabled = false;
        quitButtonTextENG.enabled = false;

        resumeButtonTextPL.enabled = true;
        saveGameButtonTextPL.enabled = true;
        optionsButtonTextPL.enabled = true;
        quitButtonTextPL.enabled = true;

    }

    public void SetENGTexts()
    {
        resumeButtonTextENG.enabled = true;
        saveGameButtonTextENG.enabled = true;
        optionsButtonTextENG.enabled = true;
        quitButtonTextENG.enabled = true;

        resumeButtonTextPL.enabled = false;
        saveGameButtonTextPL.enabled = false;
        optionsButtonTextPL.enabled = false;
        quitButtonTextPL.enabled = false;

    }
}
