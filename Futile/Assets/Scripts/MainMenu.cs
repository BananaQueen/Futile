using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text newGameButtonTextENG;
    public Text loadGameButtonTextENG;
    public Text optionsButtonTextENG;
    public Text quitButtonTextENG;
    public Text newGameButtonTextPL;
    public Text loadGameButtonTextPL;
    public Text optionsButtonTextPL;
    public Text quitButtonTextPL;
  
    public void NewGame()
    {
        
        SceneManager.LoadSceneAsync("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    
    public void SetPLTexts()
    {
        
        newGameButtonTextENG.enabled = false;
        loadGameButtonTextENG.enabled = false;
        optionsButtonTextENG.enabled = false;
        quitButtonTextENG.enabled = false;

        newGameButtonTextPL.enabled = true;
        loadGameButtonTextPL.enabled = true;
        optionsButtonTextPL.enabled = true;
        quitButtonTextPL.enabled = true;

    }

    public void SetENGTexts()
    {
        newGameButtonTextENG.enabled = true;
        loadGameButtonTextENG.enabled = true;
        optionsButtonTextENG.enabled = true;
        quitButtonTextENG.enabled = true;

        newGameButtonTextPL.enabled = false;
        loadGameButtonTextPL.enabled = false;
        optionsButtonTextPL.enabled = false;
        quitButtonTextPL.enabled = false;

    }
}