using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBuildingGenerator : MonoBehaviour
{

    public GameObject farolaPrefab;
    public GameObject wreckedBuildingPrefab;
    public GameObject buildingPrefab;
    public GameObject fondo;
    public GameObject trashcan;
    public GameObject trashcan2;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            var enemy = (GameObject)Instantiate(
            fondo,
            new Vector3(81.8f * (i - 1f), 8.9f, 10f),
            new Quaternion());
        }
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

            int random = Random.Range(0, 2);
            if (random == 0)
            {
                Vector3 pos = new Vector3(initial.x + 47 * (i + 1), -1.21f, -1f);
                var enemy = (GameObject)Instantiate(
                wreckedBuildingPrefab,
                pos,
                new Quaternion());
            }
            else
            {
                Vector3 pos = new Vector3(initial.x + 47 * (i + 1), 1.2f, 3f);
                var enemy = (GameObject)Instantiate(
                buildingPrefab,
                pos,
                new Quaternion());
            }
        }

        for (int i = 0; i < 1000; i++)
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                Vector3 pos = new Vector3(initial.x + 37 * (i + 1), -3.89f, 0);
                var enemy = (GameObject)Instantiate(
                trashcan,
                pos,
                new Quaternion());
            }
            else
            {
                Vector3 pos = new Vector3(initial.x + 37 * (i + 1), -3.6f, -0.6f);
                var enemy = (GameObject)Instantiate(
                trashcan2,
                pos,
                new Quaternion());
            }
        }
    }
}