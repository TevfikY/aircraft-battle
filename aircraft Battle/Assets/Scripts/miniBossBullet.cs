using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBossBullet : MonoBehaviour
{
    private float enemyDamage;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite deathAnimation;
    private bool tookTime = false;
    private float currentTime;
    [SerializeField] float deadTime =  5f;
    private bool isDead= false;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tookTime)
        {
            if (Time.time > currentTime + deadTime)
            {
                Destroy(gameObject);
            }
        }

        if (!isDead)
        {
           // bulletMove();
           
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            isDead = true;
            
            spriteRenderer.sprite = deathAnimation;
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            col.gameObject.GetComponent<PlayerStats>().playerGetHit(enemyDamage);
            Invoke("destroyBullet",0.2f);
        }
    }

  

    public virtual void bulletMove()
    {
        
    }
    
    
    
    void destroyBullet()
    {
        Destroy(gameObject);
    }
    
    public void setInitialTime(float time)
    {
        tookTime = true;
        currentTime = time;

    }

    public void setEnemyDamage(float damage)
    {
        enemyDamage = damage;
    }
}
