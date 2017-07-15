
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonigoteMove : MonoBehaviour {

    public static float changeSpeed = 10f; // constante de cambio de velocidad del movimiento
    private Animator animator;

    public GameObject balaPrefab;
    public Transform balaSpawn;
    public AudioClip clip;


    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

        balaSpawn = GameObject.Find("Monigote").transform;

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
        if (Input.GetKeyDown(KeyCode.W))
        {
            //transform.Translate(Vector3.up * changeSpeed * Time.deltaTime);
            if (GetComponent<Rigidbody2D>().velocity.y == 0)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8100);
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioSource.PlayClipAtPoint(clip, this.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.Save();
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {

        }

        if (Input.GetKey(KeyCode.Alpha1) && PlayerPrefs.GetInt("WaitCountShield") <= 0)
        {
            // el jugador quiere ponerse el shield!
            // si ha conseguido la puntuacion necesaria se lo ponemos
            if (PlayerPrefs.GetInt("ShieldAllowed") == 1)
            {
                // Puede ponerse shield!
                PlayerPrefs.SetInt("ShieldSet", 1);
                print("timing shield to 1");
                PlayerPrefs.SetInt("TimingShield", 1);
                GameObject.FindGameObjectWithTag("Shield").GetComponentInChildren<SpriteRenderer>().enabled = true;
                
                //SpriteRenderer.FindObjectOfType<SpriteRenderer>().enabled = false;
            }
            else
            {
                // No puede :(
            }
        }

        if (Input.GetKey(KeyCode.Alpha2) && PlayerPrefs.GetInt("WaitCountDoubleShot") <= 0)
        {
            // el jugador quiere ponerse el shield!
            // si ha conseguido la puntuacion necesaria se lo ponemos
            if (PlayerPrefs.GetInt("DoubleShotAllowed") == 1)
            {
                // Puede ponerse DS!
                PlayerPrefs.SetInt("DoubleShotSet", 1);
                print("timing doubleShot to 1");
                PlayerPrefs.SetInt("TimingDoubleShot", 1);

                print("Double shot set!!!");
            }
            else
            {
                // No puede :(
            }
        }




        // control del sonido
        if (Input.GetKeyDown(KeyCode.U))
        {
            AudioListener.pause = false;
            AudioListener.volume = 1;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioListener.pause = true;
            AudioListener.volume = 0;
        }

        // shoot?
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerPrefs.GetInt("DoubleShotSet") == 1)
            {
                StartCoroutine(nFire(2, 0.05f));
            }
            else
            {
                this.Fire();
            } 
        }
    }

    IEnumerator nFire(int numberOfShoots, float seconds)
    {
        this.Fire();

        yield return new WaitForSeconds(seconds);
        
        this.Fire();
    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab

        Vector3 position;

        if (animator.GetBool("backwards"))
        {
            position = new Vector3(balaSpawn.position.x - 1, balaSpawn.position.y, 0);
        }
        else
        {
            position = new Vector3(balaSpawn.position.x + 1, balaSpawn.position.y, 0);
        }

        var bullet = (GameObject)Instantiate(
            balaPrefab,
            position,
            balaSpawn.rotation);

        int bulletVelocity = 30;

        // Add velocity to the bullet
        if (animator.GetBool("backwards"))
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -bulletVelocity;
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletVelocity;
        }
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 8.0f);
    }
}
