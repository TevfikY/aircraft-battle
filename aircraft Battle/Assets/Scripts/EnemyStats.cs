using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private float hp;
    private float damage;
    [SerializeField] EnemyConfigCreatorCode enemyConfig;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBodyOfEnemy;
    void Start()
    {
        updateStats();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBodyOfEnemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateStats()
    {
        hp = enemyConfig.getHP();
        damage = enemyConfig.getDamage();
    }

    public void hitEnemy(float damage)
    {
        hp = hp - damage;
        
        if (hp <= 0)
        {
            spriteRenderer.sprite = enemyConfig.getSprite();
            rigidBodyOfEnemy.velocity = Vector2.zero;
            Invoke("destroyEnemy",0.2f);
        }
    }

    public void destroyEnemy()
    {
        Destroy(gameObject);
    }
}
