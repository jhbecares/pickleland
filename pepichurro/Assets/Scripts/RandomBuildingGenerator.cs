using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBuildingGenerator : MonoBehaviour
{

    public GameObject farolaPrefab;
    public GameObject wreckedBuildingPrefab;
    public GameObject buildingPrefab;

    // Use this for initialization
    void Start()
    {
        Vector3 initial = new Vector3(-45, -3, 0);
        for (int i = 0; i < 1000; i++)
        {
            Vector3 pos = new Vector3(initial.x + 15 * i, -1.5f, 1f);
            var enemy = (GameObject)Instantiate(
            farolaPrefab,
            pos,
            new Quaternion());
        }
        for (int i = 0; i < 1000; i++)
        {
            Vector3 pos = new Vector3(initial.x + 45 * (i + 1), 2.17f, -0.3f);
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                var enemy = (GameObject)Instantiate(
                wreckedBuildingPrefab,
                pos,
                new Quaternion());
            }
            else
            {
                var enemy = (GameObject)Instantiate(
                buildingPrefab,
                pos,
                new Quaternion());
            }
        }
    }
        // Update is called once per frame
        void Update()
        {

        }
}