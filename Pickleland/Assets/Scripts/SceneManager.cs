﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Highscore"));
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Puntos"));
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Vida"));
	}
	
	// Update is called once per frame
	void Update () {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Load" && Input.GetKeyDown(KeyCode.S))
        {
           // Application.LoadLevel("Level0");
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            AudioListener.pause = false;
            AudioListener.volume = 1;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioListener.pause = true;
            AudioListener.volume = 0;
        }
        if (PlayerPrefs.GetInt("Lifes") <= 0)
        {
            Application.LoadLevel("GameOver");
        }
	}
}