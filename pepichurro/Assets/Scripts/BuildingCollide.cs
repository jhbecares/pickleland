using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "Enviorment" && (other.tag == "Bala" || other.tag == "BalaEnemigo"))
        {
            Destroy(other.gameObject);
        }
    }
}
