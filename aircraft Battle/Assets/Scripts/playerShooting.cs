using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class playerShooting : MonoBehaviour
{
    private GameObject bullet;
    private GameObject bullet2;
    private GameObject bullet3;
    [SerializeField] private GameObject[] bulletObjects = new GameObject[2];
    // CurrentBulletType = 0 is for single fire per turret.
    // CurrentBulletType = 1 is double fire per turret.
    private int CurrentBulletType = 0;
    // CurrentturretForm = 0 is one turret on plane.
    // CurrentturretForm = 1 is two turret on plane.
    // CurrentturretForm = 2 is tree turret on plane.
    private int CurrentturretForm = 0;
    private float bulletSpeed = 600f;
    [SerializeField] private float bulletDamage = 1f;
    private float timeReseter;
    [SerializeField] private float timeBetweenPlayerShots = 1f;
    void Start()
    {
        timeReseter = Time.time;
        bulletDamage = GetComponent<PlayerStats>().getDamage();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "enemy" )
        {
            
            if (Time.time > timeReseter)
            {

                if (CurrentturretForm == 0)
                {
                        bullet = Instantiate(bulletObjects[CurrentBulletType], transform.GetChild(2).position,
                            transform.GetChild(2).rotation);
                        bullet.GetComponent<bulletAction>().setInitialTime(Time.time);
                        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up*bulletSpeed*Time.deltaTime;
                        timeReseter = Time.time + timeBetweenPlayerShots;
                        bullet.GetComponent<bulletAction>().bulletDamage = bulletDamage; 
                    
                    
                }
                else if (CurrentturretForm == 1)
                {
                    
                        bullet = Instantiate(bulletObjects[CurrentBulletType], transform.GetChild(0).position,
                            transform.GetChild(0).rotation);
                        bullet2 = Instantiate(bulletObjects[CurrentBulletType], transform.GetChild(1).position,
                            transform.GetChild(1).rotation);
                        bullet.GetComponent<bulletAction>().setInitialTime(Time.time);
                        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up*bulletSpeed*Time.deltaTime;
                        timeReseter = Time.time + timeBetweenPlayerShots;
                        bullet.GetComponent<bulletAction>().bulletDamage = bulletDamage; 
                        bullet2.GetComponent<bulletAction>().setInitialTime(Time.time);
                        bullet2.GetComponent<Rigidbody2D>().velocity = Vector2.up*bulletSpeed*Time.deltaTime;
                        timeReseter = Time.time + timeBetweenPlayerShots;
                        bullet2.GetComponent<bulletAction>().bulletDamage = bulletDamage;

                }
                else if (CurrentturretForm == 2)
                {
                    bullet = Instantiate(bulletObjects[CurrentBulletType], transform.GetChild(0).position,
                        transform.GetChild(0).rotation);
                    bullet2 = Instantiate(bulletObjects[CurrentBulletType], transform.GetChild(1).position,
                        transform.GetChild(1).rotation);
                    bullet3 = Instantiate(bulletObjects[CurrentBulletType], transform.GetChild(2).position,
                        transform.GetChild(2).rotation);
                    bullet.GetComponent<bulletAction>().setInitialTime(Time.time);
                    bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up*bulletSpeed*Time.deltaTime;
                    timeReseter = Time.time + timeBetweenPlayerShots;
                    bullet.GetComponent<bulletAction>().bulletDamage = bulletDamage; 
                    bullet2.GetComponent<bulletAction>().setInitialTime(Time.time);
                    bullet2.GetComponent<Rigidbody2D>().velocity = Vector2.up*bulletSpeed*Time.deltaTime;
                    timeReseter = Time.time + timeBetweenPlayerShots;
                    bullet2.GetComponent<bulletAction>().bulletDamage = bulletDamage;
                    bullet3.GetComponent<bulletAction>().setInitialTime(Time.time);
                    bullet3.GetComponent<Rigidbody2D>().velocity = Vector2.up*bulletSpeed*Time.deltaTime;
                    timeReseter = Time.time + timeBetweenPlayerShots;
                    bullet3.GetComponent<bulletAction>().bulletDamage = bulletDamage;
                }
                 



            }
            
            
            
        }
    }

    public void destroyer()
    {
        Destroy(bullet);
        
    }
    public void updateDamage(int index)
    {
        if (index == 0) bulletDamage = bulletDamage;
        else if (index == 1) bulletDamage *= 2;
    }

    /*
    public void LeftGunFire()
    {
        GameObject bullet = Instantiate(bulletObjects[CurrentBulletType], transform.GetChild(0).position,
            transform.GetChild(0).rotation);
        
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up*bulletSpeed*Time.deltaTime;
    }
    public void RightGunFire()
    {
        GameObject bullet = Instantiate(bulletObjects[CurrentBulletType], transform.GetChild(0).position,
            transform.GetChild(0).rotation);
        
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up*bulletSpeed*Time.deltaTime;
    }
    */

    public void changeBulletType(int bulletType)
    {
        CurrentBulletType = bulletType;
        
    }

    public void increaseTurretCount()
    {
        CurrentturretForm++;
    }
}
