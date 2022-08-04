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