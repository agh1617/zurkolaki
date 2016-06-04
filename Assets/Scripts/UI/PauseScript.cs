﻿using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    Canvas pauseMenu;
    bool paused;

	void Start() {
        pauseMenu = GetComponent<Canvas>();

        pauseMenu.enabled = false;
        paused = false;
	}
	
	void Update() {
        if (Input.GetButtonDown("Pause"))
        {
            if (paused) Resume();
            else Pause();
        }
	}

    public void Pause()
    {
        Time.timeScale = 0;
        paused = pauseMenu.enabled = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        paused = pauseMenu.enabled = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
