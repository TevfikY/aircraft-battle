using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAttack : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = FindObjectOfType<playerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 difference = player.gameObject.transform.position - transform.position;
        difference.Normalize();
        float rotationZ = MathF.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(0f,0f,rotationZ) ;
        
    }
}
