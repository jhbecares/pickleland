using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRayo : MonoBehaviour {

    public Transform monigote;
    public GameObject balaPrefab;
    Transform balaSpawn;

    public int fireTime;
    int fireCont;

	// Use this for initialization
	void Start () {
        monigote = GameObject.Find("Monigote").transform;
        fireTime = 60;
        fireCont = 0;
	}
	
	// Update is called once per frame
	void Update () {
        fireCont++;
        if (fireCont >= fireTime)
        {
            checkHit(1);
            checkHit(-1);
            fireCont = 0;
        }
        
    }

    void checkHit(int left)
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(this.transform.position, new Vector2(left * 1.0f, 0.0f), 30.0f, 1<<9);

        for (int i = 0; i < hit.Length; i++)
        {
            print(hit[i].collider.tag);


            if (hit[i].collider.tag != "EnemyPickle")
            {
                print(hit[i].collider.tag);
                if (hit[i].collider.tag == "Monigote")
                {
                    // enemy can see the player!
                    print("Enemy can see the player");
                    Fire();
                }
            }
            else
            {
                print("Transform is null");
            }
        }
    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab

        Vector3 position;
        
        balaSpawn = this.transform;

        bool enemyLeft = this.transform.position.x < monigote.transform.position.x;

        if (enemyLeft)
        {
            position = new Vector3(balaSpawn.position.x + 1, balaSpawn.position.y, 0);
        }
        else
        {
            position = new Vector3(balaSpawn.position.x - 1, balaSpawn.position.y, 0);
        }

        var bullet = (GameObject)Instantiate(
            balaPrefab,
            position,
            balaSpawn.rotation);

        int bulletVelocity = 20;

        // Add velocity to the bullet
        if (enemyLeft)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletVelocity;
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * -bulletVelocity;
        }
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 8.0f);
    }
}
