using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletAction : MonoBehaviour
{
    [SerializeField] private Sprite explodeSprite;
    private SpriteRenderer spriteRenderer;
    private bool tookTime = false;
    private float currentTime;
    [SerializeField] float deadTime =  5f;
    private bool isDead = false;
    public float bulletDamage;
    private bool isAlive = true;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (tookTime)
        {
            if (Time.time > currentTime + deadTime)
            {
                Destroy(gameObject);
            }
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            spriteRenderer.sprite = explodeSprite;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            col.gameObject.GetComponent<EnemyStats>().hitEnemy(bulletDamage);
            
            Invoke("destroyBullet",0.2f);
            
        }
        
    }

    
    public void setInitialTime(float time)
    {
        tookTime = true;
        currentTime = time;

    }
    
    void destroyBullet()
    {
        Destroy(gameObject);
    }
}
