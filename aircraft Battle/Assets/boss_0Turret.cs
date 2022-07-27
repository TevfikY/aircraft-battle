using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class boss_0Turret : MonoBehaviour
{
   private GameObject player;
    private float resetTimer;
    [SerializeField] private float attackSPeed = 3f;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float bulletspeed = 5f;
    private float bulletCount = 0;
    float timeReseter;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] float bulletPerSecond = 0.1f;
    private float bulletPerSecondReseter;
    private float enemyDamage;
    private bool inPlace = false;
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
        
        bulletMove();
        
        
        
        
        
    }
    public void setInPlace(bool state)
    {
        inPlace = state;
    }
    public void bulletMove()
    {
        
       
        
        
        if (bulletCount < 10)
        {
            if (Time.time > timeReseter)
            {
                if (Time.time > bulletPerSecondReseter && inPlace)
                {
                    Vector2 difference = player.gameObject.transform.position - transform.position;
                    difference.Normalize();
                    float rotationZ = MathF.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 90;
                    int rotation = (int)rotationZ;
                    int rotationT = Random.Range(rotation - 25, rotation + 25);
                    transform.rotation = Quaternion.Euler(0f,0f,rotationT) ;
                    GameObject bullet = Instantiate(enemyBullet, transform.GetChild(0).position,
                        transform.GetChild(0).rotation);
                    
                    bullet.GetComponent<Rigidbody2D>().velocity =  -1* transform.up * bulletspeed;
                    bulletPerSecondReseter = Time.time + bulletPerSecond;
                    bulletCount++;
                    bullet.GetComponent<Transform>().rotation = Quaternion.Euler(0,0,rotationT);
                    bullet.GetComponent<boss_0BulletAction>().setInitialTime(Time.time);
                    bullet.GetComponent<boss_0BulletAction>().setEnemyDamage(enemyDamage);
                    //bullet.GetComponent<boss_0BulletAction>().transform.Rotate(0,0,90);
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
