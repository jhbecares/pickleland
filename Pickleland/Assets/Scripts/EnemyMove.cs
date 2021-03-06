﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject bossPrefab;
    public GameObject balaPrefab;
    public Transform enemySpawn;
    public Transform enemySpawn2;
    private Transform monigote;
    public int difficultyIncreaseDistance;
    private int currentDifficultyDistance;
    // The higher the difficultyIncrease is, the more enemies will spawn.
    public int difficultyIncrease;

    public int count = 0;
    public int limitCount = 200;

    public int countAceituna = 0;
    public int limitCountAceituna = 300;

    private bool bossSpawn1;
    private bool bossSpawn2;
    // Use this for initialization
    void Start () {
        monigote = GameObject.Find("Monigote").transform;
        enemySpawn = GameObject.Find("EnemySpawn").transform;
        enemySpawn2 = GameObject.Find("EnemySpawn").transform;

        this.count = 0;
        this.countAceituna = 0;
        this.currentDifficultyDistance = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (monigote == null) Destroy(this);
        this.count++;
        this.countAceituna++;
        if (this.count >= limitCount)
        {
            // create enemy checking player pos

            //enemySpawn.position = monigote.transform.position;
            float rand = Random.Range(0, 2);
            Vector3 enemyPos;
            if (rand < 0.5f) {
                enemyPos = new Vector3(monigote.transform.position.x + 15f, -3.685f + 10f, monigote.transform.position.z);   
            }
            else
            {
                enemyPos = new Vector3(monigote.transform.position.x - 5f, -3.685f + 10f, monigote.transform.position.z);   
            }
            enemySpawn.position = enemyPos;

            var enemy = (GameObject)Instantiate(
            enemyPrefab,
            enemySpawn.position,
            enemySpawn.rotation);
            this.count = 0;

        }
        if (this.countAceituna >= this.limitCountAceituna)
        {
            // create enemy checking player pos

            //enemySpawn.position = monigote.transform.position;
            float rand = Random.Range(0, 2);
            Vector3 enemyPos;
            if (rand < 0.5f)
            {
                enemyPos = new Vector3(monigote.transform.position.x + 15f, -3.685f + 10f, monigote.transform.position.z);
            }
            else
            {
                enemyPos = new Vector3(monigote.transform.position.x - 5f, -3.685f + 10f, monigote.transform.position.z);
            }
            enemySpawn2.position = enemyPos;

            var enemy = (GameObject)Instantiate(
            enemyPrefab2,
            enemySpawn2.position,
            enemySpawn2.rotation);
            this.countAceituna = 0;

        }
        if (monigote != null && monigote.position.x > currentDifficultyDistance + difficultyIncreaseDistance)
        {
            if(limitCount > 11)
            {
                currentDifficultyDistance = (int) monigote.position.x;
                limitCount -= difficultyIncrease;
            }
            if (limitCount > 16)
            {
                currentDifficultyDistance = (int)monigote.position.x;
                limitCountAceituna -= difficultyIncrease;
            }

        }
        if (monigote != null)
        {
            if (monigote.position.x > 925 && !bossSpawn1)
            {
                bossSpawn1 = true;
                var enemy = (GameObject)Instantiate(
               bossPrefab,
               new Vector3(monigote.position.x + 50, -3.58f, -0.3f),
               enemySpawn2.rotation);
            }

            if (monigote.position.x > 960 && !bossSpawn2)
            {
                bossSpawn2 = true;
                var enemy = (GameObject)Instantiate(
               bossPrefab,
               new Vector3(monigote.position.x - 15, -3.58f, -0.3f),
               enemySpawn2.rotation);
            }
        }
    }

    void LateUpdate()
    {
        Transform t = GameObject.Find("Monigote").transform;
        
        Vector3 newPos;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("EnemyPickle"))
        {
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
    }


}
