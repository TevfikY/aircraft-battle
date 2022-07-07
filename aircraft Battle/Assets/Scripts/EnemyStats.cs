using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
     float hp = 4;
     private float damage = 1;
    [SerializeField] EnemyConfigCreatorCode enemyConfig;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBodyOfEnemy;
    private Sprite enemySprite;
    
    
    void Start()
    {
        updateStats();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBodyOfEnemy = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>().sprite;
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
            if (GetComponentInChildren<SpriteRenderer>().sprite != null)
            {
               // GetComponentInChildren<SpriteRenderer>().sprite = 
            }
            rigidBodyOfEnemy.velocity = Vector2.zero;
            Invoke("destroyEnemy",0.2f);
            FindObjectOfType<enemySpawner>().decreaseEnemyCountByOne();
        }
    }

    public void destroyEnemy()
    {
        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return damage;
    }

    
}
