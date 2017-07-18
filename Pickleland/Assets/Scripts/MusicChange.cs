using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{

    public GameObject monigote;
    public AudioClip boss1;
    public AudioClip normal;
    private bool isboss;

    // Use this for initialization
    void Start()
    {
        isboss = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xpos = monigote.transform.position.x;
        //print(xpos);
        if (xpos < 400 || (xpos > 510 && xpos < 850) || xpos > 1050)
        {
            if (isboss)
            {
                GetComponent<AudioSource>().clip = normal;
                GetComponent<AudioSource>().Play();
               isboss = false;
            }
        }
        else
        {
            //print("CAMBIO DE MUUUUUSICA LOKOOOOOOOOOOOOOOOOOOOO");
            if (!isboss)
            {
                GetComponent<AudioSource>().clip = boss1;
                GetComponent<AudioSource>().Play();
                isboss = true;
            }
        }
    }
}