using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	static public int score = 0;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Highscore"));
    }

	void Awake() {
        // If the PepichurroHighScore already exists, read it
        score = PlayerPrefs.GetInt("PepichurroHighScore", 0);
	}
	
	// Update is called once per frame
	void Update () {
		//GUIText gt = this.GetComponent<GUIText> ();
		//gt.text = "High Score: " + score;

        //Transform monigote = GameObject.FindGameObjectWithTag("Monigote").transform;
       // gt.transform.position = new Vector2(monigote.transform.position.x - 9f, monigote.transform.position.y + 4.5f);
        GameObject guiGO = GameObject.FindGameObjectWithTag("Highscore");

        TextMesh guitext = guiGO.GetComponent<TextMesh>();
        guitext.text = "High score: " + score;

        Transform monigote = GameObject.FindGameObjectWithTag("Monigote").transform;

        guitext.transform.position = new Vector2(monigote.transform.position.x - 9f, monigote.transform.position.y + 7.5f);


        // Update PepichurroHighScore in PlayerPrefs if necessary
        if (score > PlayerPrefs.GetInt("PepichurroHighScore"))
        {
            PlayerPrefs.SetInt("PepichurroHighScore", score);
            PlayerPrefs.Save();
		}
	}

}
