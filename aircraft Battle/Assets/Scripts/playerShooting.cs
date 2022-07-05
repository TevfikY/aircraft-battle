using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.UIElements;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class playerShooting : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletObjects = new GameObject[2];
    // CurrentBulletType = 0 is for single fire per turret.
    // CurrentBulletType = 1 is double fire per turret.
    private int CurrentBulletType = 0;
    // CurrentturretForm = 0 is one turret on plane.
    // CurrentturretForm = 1 is two turret on plane.
    // CurrentturretForm = 2 is tree turret on plane.
    private int CurrentturretForm = 0;
    [SerializeField] private float bulletSpeed = 100f;
    private float bulletDamage = 10f;
    private float timeReseter;
    [SerializeField] private float timeBetweenPlayerShots = 1f;
    void Start()
    {
        timeReseter = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "enemy")
        {
            if (Time.time > timeReseter)
            {
                GameObject bullet = Instantiate(bulletObjects[CurrentBulletType], transform.GetChild(2).position,
                    transform.GetChild(2).rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up*bulletSpeed*Time.deltaTime;
                timeReseter = Time.time + timeBetweenPlayerShots;
            }
            
            
        }
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
}
