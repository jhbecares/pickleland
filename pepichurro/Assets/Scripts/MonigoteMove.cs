using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonigoteMove : MonoBehaviour {

    public static float changeSpeed = 10f; // constante de cambio de velocidad del movimiento

	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * changeSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * changeSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * changeSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * changeSpeed * Time.deltaTime);
        }
	}
}
