using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisparoDirigidoManager : MonoBehaviour {

    public int neededPointsToDisparoDirigido;
    public int DisparoDirigidoTime = 150;
    int DisparoDirigidoCount = 0;
    public GameObject DisparoDirigidoIcon;

    public AudioClip DisparoDirigidoUpClip;
    public AudioClip DisparoDirigidoDownClip;
    private bool DisparoDirigidoDownSoundPlayed;

    public int waitTimeForDisparoDirigido = 300;
    int waitCount = 0;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("WaitCountDisparoDirigido", 0);
        PlayerPrefs.SetInt("DisparoDirigidoAllowed", -1);
        PlayerPrefs.SetInt("TimingDisparoDirigido", -1);
        PlayerPrefs.SetInt("DisparoDirigidoSet", -1);
        DisparoDirigidoIcon = GameObject.FindGameObjectWithTag("DDPU");
        DisparoDirigidoDownSoundPlayed = false;

    }

    // Update is called once per frame
    void Update()
    {

        //print("timing DisparoDirigido: " + PlayerPrefs.GetInt("TimingDisparoDirigido"));
        //print("DisparoDirigido allowed: " + PlayerPrefs.GetInt("DisparoDirigidoAllowed"));

        if (PlayerPrefs.GetInt("DisparoDirigidoAllowed") == 1)
        {
            print("DisparoDirigido allowed");
            if (PlayerPrefs.GetInt("TimingDisparoDirigido") == -1)
            {
                if (waitCount > 0)
                {
                    waitCount--;
                    DisparoDirigidoIcon.GetComponent<Image>().color = Color.black;
                    if (!DisparoDirigidoDownSoundPlayed)
                    {
                        AudioSource.PlayClipAtPoint(DisparoDirigidoDownClip, this.transform.position);
                        DisparoDirigidoDownSoundPlayed = true;
                    }
                }

                if (waitCount <= 0)
                {
                    DisparoDirigidoDownSoundPlayed = false;
                    PlayerPrefs.SetInt("WaitCountDisparoDirigido", 0);
                    DisparoDirigidoIcon.GetComponent<Image>().color = Color.white;
                }
            }
        }




        // Vemos si tenemos que activar la posibilidad de puntos
        int points = PlayerPrefs.GetInt("Points");

        // shield allowed -> 1
        // shield not allowed -> -1
        if (points >= neededPointsToDisparoDirigido)
        {
            PlayerPrefs.SetInt("DisparoDirigidoAllowed", 1);
            DisparoDirigidoIcon.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("DisparoDirigidoAllowed", -1);
            DisparoDirigidoIcon.SetActive(false);
        }


        if (PlayerPrefs.GetInt("TimingDisparoDirigido") == 1)
        {
            DisparoDirigidoCount++;
            if (DisparoDirigidoCount == 1)
            {
                AudioSource.PlayClipAtPoint(DisparoDirigidoUpClip, this.transform.position);
            }
            DisparoDirigidoIcon.GetComponent<Image>().color = Color.green;
            if (DisparoDirigidoCount >= DisparoDirigidoTime)
            {
                // Quitarle el escudo!
                PlayerPrefs.SetInt("DisparoDirigidoSet", -1);
                // GameObject.FindGameObjectWithTag("Shield").GetComponentInChildren<SpriteRenderer>().enabled = false;

                // resetear todo
                PlayerPrefs.SetInt("TimingDisparoDirigido", -1);
                DisparoDirigidoCount = 0;

                waitCount = waitTimeForDisparoDirigido;
            }
        }
        PlayerPrefs.SetInt("WaitCountDisparoDirigido", waitCount);

    }
}
