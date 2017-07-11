using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonigoteController : MonoBehaviour {

    public static float changeSpeed = 10f; // constante de cambio de velocidad del movimiento
    public GameObject balaPrefab;
    public Transform balaSpawn;

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

        // shoot?
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Fire();
        }
	}

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            balaPrefab,
            balaSpawn.position,
            balaSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 6;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 8.0f);
    }
}
