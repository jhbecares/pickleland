using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRayoOlive : MonoBehaviour {

    public Transform monigote;
    public AudioClip jumpClip;
    public int fireTime;
    int fireCont;

    // Use this for initialization
    void Start()
    {
        monigote = GameObject.Find("Monigote").transform;
        fireTime = 60;
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

    void checkHit(int left)
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(this.transform.position, new Vector2(left * 1.0f, 0.0f), 30.0f, 1 << 9);

        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.tag != "EnemyPickle")
            {
                print(hit[i].collider.tag);
                if (hit[i].collider.tag == "Monigote")
                {
                    // enemy can see the player!
                   
                    float xPos = hit[i].collider.transform.position.x;
                    float vel = 55;
                    float value = checkPos(xPos);
                    if (xPos < GetComponent<Transform>().position.x)
                    {
                        this.transform.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(-value, value) * vel);
                    }
                    else {
                        this.transform.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(value, value) * vel);
                    }
                    AudioSource.PlayClipAtPoint(jumpClip, this.transform.position);
                }
            }
            else
            {
                print("Transform is null");
            }
        }
    }

    private float checkPos(float x)
    {
        float enemyX = GetComponent<Transform>().position.x;
        if (enemyX < x)
        {
            return x - enemyX;
        }
        else
        {
            return enemyX - x;
        }
    }

}
