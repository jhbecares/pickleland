using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifes : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("Lifes", 5); 
    }

    void Awake()
    {
        //PlayerPrefs.SetInt ("Lives", lives);
    }

    // Update is called once per frame
    void Update()
    {
        lifes = PlayerPrefs.GetInt("Lifes");

        GameObject guiGO = GameObject.FindGameObjectWithTag("LifesTag");

        TextMesh guitext = guiGO.GetComponent<TextMesh>();
        guitext.text = "Lifes: " + lifes;

        Transform monigote =  GameObject.FindGameObjectWithTag("Monigote").transform;

        guitext.transform.position = new Vector2(monigote.transform.position.x - 9f, monigote.transform.position.y + 6f);
    }

    public static int lifes { get; set; }
}
