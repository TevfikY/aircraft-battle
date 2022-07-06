using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemy config",menuName = "new enemy config") ]
public class EnemyConfigCreatorCode : ScriptableObject
{
    [SerializeField] private float enemyHP;
    [SerializeField] private float enemyDamage;

    public float getHP()
    {
        return enemyHP;
    }

    public float getDamage()
    {
        return enemyDamage;
    }
}
