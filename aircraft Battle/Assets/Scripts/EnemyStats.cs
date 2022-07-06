using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private float hp;
    private float damage;
    [SerializeField] EnemyConfigCreatorCode enemyConfig;
    void Start()
    {
        updateStats();
        Debug.Log(hp);
        Debug.Log(damage);
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
}
