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
    private bool isDead = false;
    
    
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
        
        
        if (hp <= 0 && !isDead)
        {
            isDead = true;
            
            FindObjectOfType<enemySpawner>().decreaseEnemyCountByOne();
            spriteRenderer.sprite = enemyConfig.getSprite();
            rigidBodyOfEnemy.velocity = Vector2.zero;
            
            Invoke("destroyEnemy",0.2f);
            
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
