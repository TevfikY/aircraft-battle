using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class levelManagement : MonoBehaviour
{ 
    [SerializeField] private float backgroundSpeed = 2f;
    [SerializeField] private float speedUp = 0.2f;
    [SerializeField] private float maxSpeed = 10f;
    private int currentGrid;
    public float levelTracker = 0;
    private float spawnTracker = 0;
    public GameObject[] tilePrefabs;
    private GameObject go;
    public List<GameObject> gridList;
    public Transform playerTransform;
    private Rigidbody2D tilerb;


    private void Start()
    {
        go = GameObject.Find("StartingGrid");
        tilerb = go.GetComponent<Rigidbody2D>();
        tilerb.velocity = new Vector2(0, -backgroundSpeed);
        gridList.Add(go);
    }

    private void Update()
    {
        tilerb.velocity = new Vector2(0, -backgroundSpeed);
        if (gridList.Count == 2)
        {
            gridList[0].GetComponent<Rigidbody2D>().velocity = new Vector2(0, -backgroundSpeed);
            gridList[1].GetComponent<Rigidbody2D>().velocity = new Vector2(0, -backgroundSpeed);
        }
        if ((playerTransform.position.y > gridList[0].transform.position.y-3) && (spawnTracker < 20))
        {
            if (levelTracker % 200 < 50)
            {
                if (levelTracker % 200 == 0)
                {
                    currentGrid = 16;
                    spawnGrid(currentGrid);
                }
                else if (levelTracker % 200 == 40)
                {
                    currentGrid = 20;
                    spawnGrid(currentGrid);
                }
                else
                {
                    currentGrid = Random.Range(0, 4);
                    spawnGrid(currentGrid);
                }
            }
            else if (levelTracker % 200 < 100)
            {
                if (levelTracker % 200 == 50)
                {
                    currentGrid = 17;
                    spawnGrid(currentGrid);
                }
                else if (levelTracker % 200 == 90)
                {
                    currentGrid = 21;
                    spawnGrid(currentGrid);
                }
                else
                {
                    currentGrid = Random.Range(4, 8);
                    spawnGrid(currentGrid);
                }
            }
            else if (levelTracker % 200 < 150)
            {
                if (levelTracker % 200 == 100)
                {
                    currentGrid = 18;
                    spawnGrid(currentGrid);
                }
                else if (levelTracker % 200 == 140)
                {
                    currentGrid = 22;
                    spawnGrid(currentGrid);
                }
                else
                {
                    currentGrid = Random.Range(8, 12);
                    spawnGrid(currentGrid);
                }
            }
            else if (levelTracker % 200 < 200)
            {
                if (levelTracker % 200 == 150)
                {
                    currentGrid = 19;
                    spawnGrid(currentGrid);
                }
                else if (levelTracker % 200 == 190)
                {
                    currentGrid = 23;
                    spawnGrid(currentGrid);
                }
                else
                {
                    currentGrid = Random.Range(12, 16);
                    spawnGrid(currentGrid);
                }
            }
        }
        if (gridList[0].transform.position.y < -15f) //-9.6f
        {
            destroyGrid(gridList[0]);
        }
    }

    private void spawnGrid(int tileIndex)
    {
        go = Instantiate(tilePrefabs[tileIndex]);
        go.transform.position = new Vector2(0, gridList[gridList.Count - 1].transform.position.y + 10);
        gridList.Add(go);
        tilerb = go.GetComponent<Rigidbody2D>();
        tilerb.velocity = new Vector2(0, -backgroundSpeed);
        if (backgroundSpeed < maxSpeed)
        {
            backgroundSpeed += speedUp;
        }
        spawnTracker += 10;
        levelTracker += 10;
    }

    void destroyGrid(GameObject destroyableObject)
    {
        Destroy(destroyableObject);
        gridList.RemoveAt(0);
        spawnTracker -= 10;
    }
}