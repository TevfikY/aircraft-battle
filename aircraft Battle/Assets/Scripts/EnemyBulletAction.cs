using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletAction : MonoBehaviour
{
    private float enemyDamage;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite deathAnimation;
    private bool tookTime = false;
    private float currentTime;
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("player GOT HITTTT");
            spriteRenderer.sprite = deathAnimation;
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            col.gameObject.GetComponent<PlayerStats>().playerGetHit(enemyDamage);
            Invoke("destroyBullet",0.2f);
        }
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
