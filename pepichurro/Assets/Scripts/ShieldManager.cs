using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour {

    /*
     * Si llegamos a X puntos que se definiran en la variable
     * ShieldPoints (y se consultara en ShieldAllowed), el 
     * jugador podra pulsar 1 para tener un escudo durante
     * varios segundos. Despues, estara tiempo sin poder ponerse el escudo
     * 
     * To think: ponemos un maximo de escudos?
     */
    public int neededPointsToShield = 200;
    public int shieldTime = 200;
    int shieldCount = 0;

    public int waitTimeForShield = 200;
    int waitCount = 0;

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("WaitCountShield", 0);
	}
	
	// Update is called once per frame
	void Update () {

        print("timing shield: " + PlayerPrefs.GetInt("TimingShield"));
        print("shield allowed: " + PlayerPrefs.GetInt("ShieldAllowed"));

        if (PlayerPrefs.GetInt("TimingShield") == -1)
        {
            if (waitCount > 0)
                waitCount--;

            print("wait count: " + waitCount);
            if (waitCount <= 0)
            {
                PlayerPrefs.SetInt("ShieldAllowed", 1);
            }
        }




        // Vemos si tenemos que activar la posibilidad de puntos
        int points = PlayerPrefs.GetInt("Points");

        // shield allowed -> 1
        // shield not allowed -> -1
        if (points >= neededPointsToShield)
        {
            PlayerPrefs.SetInt("ShieldAllowed", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ShieldAllowed", -1);
        }
        

        if (PlayerPrefs.GetInt("TimingShield") == 1)
        {
            shieldCount++;
            if (shieldCount >= shieldTime)
            {
                // Quitarle el escudo!
                PlayerPrefs.SetInt("ShieldSet", -1);
                GameObject.FindGameObjectWithTag("Shield").GetComponentInChildren<SpriteRenderer>().enabled = false;

                // resetear todo
                PlayerPrefs.SetInt("TimingShield", -1);
                shieldCount = 0;

                waitCount = waitTimeForShield;
            }
        }
        PlayerPrefs.SetInt("WaitCountShield", waitCount);

	}
}
