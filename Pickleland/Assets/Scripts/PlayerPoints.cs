using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("Points", 0);
    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        points = PlayerPrefs.GetInt("Points");

        GameObject guiGO = GameObject.FindGameObjectWithTag("PuntosTag");

        Text guitext = guiGO.GetComponent<Text>();
        guitext.text = "Points: " + points;
        /*
        if (GameObject.FindGameObjectWithTag("Monigote") != null)
        {
            Transform monigote = GameObject.FindGameObjectWithTag("Monigote").transform;

            guitext.transform.position = new Vector2(monigote.transform.position.x - 7f, monigote.transform.position.y + 4.5f);
        }
        */
        if (points > 0 && points > HighScore.score) 
            HighScore.score = points;
    }

    public static int points { get; set; }
}
