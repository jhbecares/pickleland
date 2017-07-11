using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {


    private Animator animator;

    private bool right;

	// Use this for initialization
	void Start () {

        animator = GameObject.Find("Monigote").GetComponent<Animator>();

        if (animator.GetBool("backwards"))
        {
            right = false;
        }
        else
        {
            right = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Transform balaSpawn = this.transform;

        if (right)
        {
            balaSpawn.transform.position = new Vector3(balaSpawn.transform.position.x + 0.1f,
                balaSpawn.transform.position.y, balaSpawn.transform.position.z);
        }
        else
        {
            balaSpawn.transform.position = new Vector3(balaSpawn.transform.position.x - 0.1f,
                balaSpawn.transform.position.y, balaSpawn.transform.position.z);
        }

	}
}
