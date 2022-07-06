using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class levelManagement : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public Transform playerTransform;



    private void Update()
    {
        if (playerTransform.position.y > zSpawn)
        {
            spawnTile(0);
        }
    }

    public void spawnTile(int tileIndex)
    {
        GameObject a = Instantiate(tilePrefabs[tileIndex]);
        a.transform.position = new Vector2(0, 10 + zSpawn);
        zSpawn += 10;
    }
}
