using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAttack : MonoBehaviour
{
    private GameObject player;
    private float resetTimer;
    [SerializeField] private float attackSPeed = 3f;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float speed = 300f;
    private float bulletCount = 0;
    float timeReseter;
    [SerializeField] float timeBetweenShots = 3f;
    [SerializeField] float bulletPerSecond = 0.2f;
    private float bulletPerSecondReseter;
    private float enemyDamage;
    void Start()
    {
        player = FindObjectOfType<playerMovement>().gameObject;
        timeReseter = Time.time + 1f;
        enemyDamage = 2f;
        bulletPerSecondReseter = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 difference = player.gameObject.transform.position - transform.position;
        difference.Normalize();
        float rotationZ = MathF.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(0f,0f,rotationZ) ;

        
        
        
        
    }
}
