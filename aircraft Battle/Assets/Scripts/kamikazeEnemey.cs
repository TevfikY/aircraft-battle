using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamikazeEnemey : MonoBehaviour
{
    private Transform playerPos;
    [SerializeField] private float speed = 0.1f;
    private float enemyDamage;
    private EnemyStats _enemyStats;
    void Start()
    {
        enemyDamage = GetComponent<EnemyStats>().GetDamage();
        playerPos = FindObjectOfType<playerMovement>().transform;
        _enemyStats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position != (Vector2)playerPos.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            col.gameObject.GetComponent<PlayerStats>().playerGetHit(enemyDamage);
            _enemyStats.hitEnemy(100f);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void destroyEnemy()
    {
        Destroy(gameObject);
    }
}
