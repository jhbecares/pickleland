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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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
	}
}
