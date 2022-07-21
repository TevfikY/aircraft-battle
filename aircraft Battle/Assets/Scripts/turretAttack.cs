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
    [SerializeField] private float bulletspeed = 300f;
    private float bulletCount = 0;
    float timeReseter;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] float bulletPerSecond = 0.3f;
    private float bulletPerSecondReseter;
    private float enemyDamage;
    void Start()
    {
        player = FindObjectOfType<playerMovement>().gameObject;
        timeReseter = Time.time + 3f;
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
        bulletMove();
        
        
        
        
        
    }

    public void bulletMove()
    {
        
       
        
        
        if (bulletCount < 5)
        {
            if (Time.time > timeReseter)
            {
                if (Time.time > bulletPerSecondReseter)
                {
                    GameObject bullet = Instantiate(enemyBullet, transform.GetChild(0).position,
                        transform.GetChild(0).rotation);
                    
                    bullet.GetComponent<Rigidbody2D>().velocity =  -1* transform.up * bulletspeed;
                    bulletPerSecondReseter = Time.time + bulletPerSecond;
                    bulletCount++;
                    bullet.GetComponent<miniBossBullet>().setInitialTime(Time.time);
                    bullet.GetComponent<miniBossBullet>().setEnemyDamage(enemyDamage);
                    bullet.GetComponent<miniBossBullet>().transform.Rotate(0,0,90);
                }
            }
            
        }
        else
        {
            
            timeReseter = Time.time + timeBetweenShots;
            bulletCount = 0;
        }
    }
}
