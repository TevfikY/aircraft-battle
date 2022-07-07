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
    private int usingTilemap;
    

    private void Update()
    {
        if (playerTransform.position.y > zSpawn)
        {
            if (zSpawn < 50)
            {
                usingTilemap = Random.Range(0, 4);
                spawnTile(usingTilemap);
            }
            else if (zSpawn == 50)
            {
                spawnTile(4);
            }
            else if (zSpawn < 100)
            {
                usingTilemap = Random.Range(5, 8);
                spawnTile(usingTilemap);
            }
        }
    }

    public void spawnTile(int tileIndex)
    {
        GameObject a = Instantiate(tilePrefabs[tileIndex]);
        a.transform.position = new Vector2(0, 10 + zSpawn);
        zSpawn += 10;
    }
}
