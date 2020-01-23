using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject menu;
    bool Paused = false;

    void Start()
    {
        menu.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused == true)
            {
                Time.timeScale = 1.0f;
                menu.gameObject.SetActive(false);
                Paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                menu.gameObject.SetActive(true);
                Paused = true;
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        menu.gameObject.SetActive(false);
    }
}
