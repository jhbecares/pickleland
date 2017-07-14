using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleShotManager : MonoBehaviour {

    /*
     * Si llegamos a X puntos que se definiran en la variable
     * ShieldPoints (y se consultara en ShieldAllowed), el 
     * jugador podra pulsar 1 para tener un escudo durante
     * varios segundos. Despues, estara tiempo sin poder ponerse el escudo
     * 
     * To think: ponemos un maximo de escudos?
     */
/*    public int neededPointsToDoubleShot = 50;
    public int doubleShotTime = 100;
    int doubleShotCount = 0;

    public int cooldownDoubleShot = 100;
    int waitCountDoubleShot = 0;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("WaitCountDoubleShot", 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Alpha2) && PlayerPrefs.GetInt("TimingDoubleShot") <= 0)
        {
            print("Dobleshot a topeeeee");
            // el jugador quiere ponerse el shield!
            // si ha conseguido la puntuacion necesaria se lo ponemos
            if (PlayerPrefs.GetInt("DoubleShotAllowed") == 1)
            {
                // Puede ponerse shield!
                PlayerPrefs.SetInt("DoubleShotSet", 1);
                //print("timing shield to 1");
                PlayerPrefs.SetInt("TimingDoubleShot", 1);
                //GameObject.FindGameObjectWithTag("Shield").GetComponentInChildren<SpriteRenderer>().enabled = true;

                //SpriteRenderer.FindObjectOfType<SpriteRenderer>().enabled = false;
            }
            else
            {
                // No puede :(
            }
        }

        if (PlayerPrefs.GetInt("TimingDoubleShot") == -1)
        {
            if (waitCountDoubleShot > 0)
                waitCountDoubleShot--;

            print("wait count: " + waitCountDoubleShot);
            if (waitCountDoubleShot <= 0)
            {
                PlayerPrefs.SetInt("DoubleShotAllowed", 1);
            }
        }




        // Vemos si tenemos que activar la posibilidad de puntos
        int points = PlayerPrefs.GetInt("Points");

        // shield allowed -> 1
        // shield not allowed -> -1
        if (points >= neededPointsToDoubleShot)
        {
            PlayerPrefs.SetInt("DoubleShotAllowed", 1);
        }
        else
        {
            PlayerPrefs.SetInt("DoubleShotAllowed", -1);
        }


        if (PlayerPrefs.GetInt("DoubleShotAllowed") == 1)
        {
            doubleShotCount++;
            if (doubleShotCount >= doubleShotTime)
            {
                // Quitarle el escudo!
                PlayerPrefs.SetInt("DoubleShotSet", -1);
                //GameObject.FindGameObjectWithTag("Shield").GetComponentInChildren<SpriteRenderer>().enabled = false;

                // resetear todo
                PlayerPrefs.SetInt("TimingDoubleShot", -1);
                doubleShotCount = 0;

                waitCountDoubleShot = cooldownDoubleShot;
            }
        }
        PlayerPrefs.SetInt("WaitCountDoubleShot", waitCountDoubleShot);

    }*/


    public int neededPointsToDoubleShot;
    public int doubleShotTime = 200;
    int doubleShotCount = 0;
    public GameObject DSIcon;

    public int waitTimeForDoubleShot = 200;
    int waitCount = 0;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("WaitCountDoubleShot", 0);
        PlayerPrefs.SetInt("DoubleShotAllowed", -1);
        PlayerPrefs.SetInt("TimingDoubleShot", -1);
        PlayerPrefs.SetInt("DoubleShotSet", -1);
        DSIcon = GameObject.FindGameObjectWithTag("DSPU");
    }

    // Update is called once per frame
    void Update()
    {

        print("timing doubleshot: " + PlayerPrefs.GetInt("TimingDoubleShot"));
        print("doubleshot allowed: " + PlayerPrefs.GetInt("DoubleShotAllowed"));

        if (PlayerPrefs.GetInt("DoubleShotAllowed") == 1)
        {
            print("doubleshot allowed");
            if (PlayerPrefs.GetInt("TimingDoubleShot") == -1)
            {
                if (waitCount > 0)
                {
                    waitCount--;
                    DSIcon.GetComponent<Image>().color = Color.black;
                }

                print("wait count: " + waitCount);
                if (waitCount <= 0)
                {
                    PlayerPrefs.SetInt("WaitCountDoubleShot", 0);
                    DSIcon.GetComponent<Image>().color = Color.white;
                }
            }
        }




        // Vemos si tenemos que activar la posibilidad de puntos
        int points = PlayerPrefs.GetInt("Points");

        // shield allowed -> 1
        // shield not allowed -> -1
        if (points >= neededPointsToDoubleShot)
        {
            PlayerPrefs.SetInt("DoubleShotAllowed", 1);
            DSIcon.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("DoubleShotAllowed", -1);
            DSIcon.SetActive(false);
        }


        if (PlayerPrefs.GetInt("TimingDoubleShot") == 1)
        {
            doubleShotCount++;

            DSIcon.GetComponent<Image>().color = Color.green;
            if (doubleShotCount >= doubleShotTime)
            {
                // Quitarle el escudo!
                PlayerPrefs.SetInt("DoubleShotSet", -1);
               // GameObject.FindGameObjectWithTag("Shield").GetComponentInChildren<SpriteRenderer>().enabled = false;

                // resetear todo
                PlayerPrefs.SetInt("TimingDoubleShot", -1);
                doubleShotCount = 0;

                waitCount = waitTimeForDoubleShot;
            }
        }
        PlayerPrefs.SetInt("WaitCountDoubleShot", waitCount);

    }
}
