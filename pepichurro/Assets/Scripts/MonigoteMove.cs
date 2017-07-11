
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonigoteMove : MonoBehaviour {

    public static float changeSpeed = 10f; // constante de cambio de velocidad del movimiento
    private Animator animator;

    public GameObject balaPrefab;
    public Transform balaSpawn;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        balaSpawn = GameObject.Find("Monigote").transform;
	}

	// Update is called once per frame
	void Update () {
        animator.SetBool("walking", false);
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("walking", true);
            animator.SetBool("backwards", true);
            transform.Translate(Vector3.left * changeSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walking", true);
            animator.SetBool("backwards", false);
            transform.Translate(Vector3.right * changeSpeed * Time.deltaTime);
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

        if (animator.GetBool("backwards"))
        {
            balaSpawn.position = new Vector3(balaSpawn.position.x - 1, balaSpawn.position.y, 0);
        }
        else
        {
            balaSpawn.position = new Vector3(balaSpawn.position.x + 1, balaSpawn.position.y, 0);
        }

        var bullet = (GameObject)Instantiate(
            balaPrefab,
            balaSpawn.position,
            balaSpawn.rotation);

        int bulletVellocity = 30;

        // Add velocity to the bullet
        if (animator.GetBool("backwards"))
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -bulletVellocity;
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletVellocity;
        }
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 8.0f);
    }
}
