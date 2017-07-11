using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject balaPrefab;
    public Transform enemySpawn;
    private Transform monigote;

    public int count = 0;
    public int limitCount = 400;

	// Use this for initialization
	void Start () {
        monigote = GameObject.Find("Monigote").transform;
        enemySpawn = GameObject.Find("EnemyPickle").transform;
        this.count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        print(this.count);
        this.count++;
        if (this.count >= limitCount)
        {
            // create enemy checking player pos

            //enemySpawn.position = monigote.transform.position;
            Vector3 enemyPos = new Vector3(monigote.transform.position.x + 5f, -3.685f, monigote.transform.position.z);
            enemySpawn.position = enemyPos;

            var enemy = (GameObject)Instantiate(
            enemyPrefab,
            enemySpawn.position,
            enemySpawn.rotation);

            this.count = 0;
        }

	}
}
