using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameOver" && Input.GetKeyDown(KeyCode.R)) 
        {
            // Restart
            //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            Application.LoadLevel("Level0");
        }
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameOver" 
            && (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape)))
        {
            // Restart
            //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            Application.Quit();
        }
	}
}
