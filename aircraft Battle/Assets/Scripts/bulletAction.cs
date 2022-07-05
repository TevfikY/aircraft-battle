using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletAction : MonoBehaviour
{
    [SerializeField] private Sprite explodeSprite;
    private SpriteRenderer spriteRenderer;
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
        if (col.gameObject.tag == "enemy")
        {
            spriteRenderer.sprite = explodeSprite;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Invoke("destroyBullet",0.2f);
            
        }
    }

    void destroyBullet()
    {
        Destroy(gameObject);
    }
}
