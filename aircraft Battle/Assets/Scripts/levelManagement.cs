using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManagement : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;

    private void Start()
    {
        spawnTile(0);
    }

    public void spawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLength;
    }
}
