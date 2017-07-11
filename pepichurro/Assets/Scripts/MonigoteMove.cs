using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonigoteMove : MonoBehaviour {

    public static float changeSpeed = 10f; // constante de cambio de velocidad del movimiento
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
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
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * changeSpeed * Time.deltaTime);
        }

        
    }
}
