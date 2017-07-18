using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Script : MonoBehaviour {
    public Transform monigote;
    public GameObject balaPrefab;
    Transform balaSpawn;

    public int fireTime;
    int fireCont;

    // Use this for initialization
    void Start()
    {
        monigote = GameObject.Find("Monigote").transform;
        fireCont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fireCont++;
        if (fireCont >= fireTime)
        {
            checkHit(1);
            checkHit(-1);
            fireCont = 0;
        }

    }

    private void LateUpdate()
    {
        GameObject go = this.gameObject;
        Transform t = monigote;
        Vector3 newPos;
        return;
        if (go.transform.position.y <= t.position.y + 0.5f)
        {
            if (go.transform.position.x < t.position.x)
            {
                newPos = new Vector3(go.transform.position.x + 0.05f, go.transform.position.y,
                 go.transform.position.z);
            }
            else
            {
                newPos = new Vector3(go.transform.position.x - 0.05f, go.transform.position.y,
                 go.transform.position.z);
            }
            go.transform.position = newPos;
        }
        else
        {
            //print("la altura no es la miiiisma loka");
        }
    }

    void checkHit(int left)
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(this.transform.position, new Vector2(left * 1.0f, 0.0f), 30.0f, 1 << 9);

        for (int i = 0; i < hit.Length; i++)
        {
            //print(hit[i].collider.tag);
            if (hit[i].collider.tag != "EnemyPickle")
            {
                //print(hit[i].collider.tag);
                if (hit[i].collider.tag == "Monigote")
                {
                    // enemy can see the player!
                    //print("Enemy can see the player");
                    Fire();

                }
            }
            else
            {
                //print("Transform is null");
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

        int bulletVelocity = 15;

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
