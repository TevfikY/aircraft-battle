using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
     float timeReseter ;
    [SerializeField] float timeBetweenShots = 3f;
    [SerializeField] float bulletPerSecond = 0.2f;
     private float bulletPerSecondReseter;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] float  bulletSpeed = 300f;
    private float bulletCount = 0;
    private float enemyDamage;
    void Start()
    {
        timeReseter = Time.time + 1f;
        
        bulletPerSecondReseter = Time.time;
        enemyDamage = GetComponent<EnemyStats>().GetDamage();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (bulletCount < 3)
        {
            if (Time.time > timeReseter)
            {
                if (Time.time > bulletPerSecondReseter)
                {
                    GameObject bullet = Instantiate(enemyBullet, transform.GetChild(0).position,
                        transform.GetChild(0).rotation);
                    
                    bulletPerSecondReseter = Time.time + bulletPerSecond;
                    bulletCount++;
                    bullet.GetComponent<EnemyBulletAction>().setInitialTime(Time.time);
                    bullet.GetComponent<EnemyBulletAction>().setEnemyDamage(enemyDamage);
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
