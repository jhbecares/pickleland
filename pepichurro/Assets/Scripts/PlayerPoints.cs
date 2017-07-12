using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        TextMesh guitext = guiGO.GetComponent<TextMesh>();
        guitext.text = "Points: " + points;

        Transform monigote = GameObject.FindGameObjectWithTag("Monigote").transform;

        guitext.transform.position = new Vector2(monigote.transform.position.x - 9f, monigote.transform.position.y + 5f);
    }

    public static int points { get; set; }
}
