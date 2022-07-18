using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class levelManagement : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public List<GameObject> gridList;
    public float levelTracker = 0;
    public Transform playerTransform;
    private int currentGrid;

    private void Start()
    {
        /*GameObject startingGrid = Instantiate(tilePrefabs[16]);
        startingGrid.transform.position = new Vector2(0, 0);*/
        gridList.Add(GameObject.Find("StartingGrid"));
    }

    private void Update()
    {
        if (playerTransform.position.y > levelTracker)
        {
            if (levelTracker % 200 < 50)
            {
                currentGrid = Random.Range(0, 4);
                spawnGrid(currentGrid);
            }
            else if (levelTracker % 200 < 100)
            {
                currentGrid = Random.Range(4, 8);
                spawnGrid(currentGrid);
            }
            else if (levelTracker % 200 < 150)
            {
                currentGrid = Random.Range(8, 12);
                spawnGrid(currentGrid);
            }
            else if (levelTracker % 200 < 200)
            {
                currentGrid = Random.Range(12, 16);
                spawnGrid(currentGrid);
            }
        }
    }

    public void spawnGrid(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex]);
        go.transform.position = new Vector2(0, levelTracker + 10);
        levelTracker += 10;
        gridList.Add(go);
        if (playerTransform.position.y > gridList[0].transform.position.y + 10)
        {
            Destroy(gridList[0]);
            gridList.RemoveAt(0);
        }
    }
}