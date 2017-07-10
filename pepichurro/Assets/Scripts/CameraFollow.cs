using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform monigote;

	// Use this for initialization
    void Start()
    {
        monigote = GameObject.Find("Monigote").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerpos = monigote.position;
        playerpos.z = transform.position.z;
        transform.position = playerpos;
	}
}
