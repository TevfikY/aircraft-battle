using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollower : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0,2,-10);
    private Transform player;
    void Start()
    {
        player = FindObjectOfType<playerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + offset.y, offset.z);
    }
}
