using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    private Transform player;
   [SerializeField] private Vector2 offset;
    void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + (Vector3) offset;
    }

    public void disableBarrier()
    {
        Destroy(gameObject);
    }
}
