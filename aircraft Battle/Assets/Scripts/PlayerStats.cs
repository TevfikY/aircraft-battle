using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float playerHP;
    [SerializeField] private float playerDamage;
    [SerializeField] private Image firstHeart;
    [SerializeField] private Image secondHeart;
    [SerializeField] private Image thirdHeart;
    private float maxHP;
    void Start()
    {
        maxHP = playerHP;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player HP is "+playerHP);
    }

    public void playerGetHit(float damage)
    {
        playerHP = playerHP - damage;
        
        if (playerHP / maxHP > (8/12f))
        {
            firstHeart.enabled = true;
            secondHeart.enabled = true;
            thirdHeart.enabled = true;
        }
        else if (playerHP / maxHP > (4/12f))
        {
            firstHeart.enabled = true;
            secondHeart.enabled = true;
            thirdHeart.enabled = false;
        }
        else if (playerHP / maxHP > (4 / 12f))
        {
            firstHeart.enabled = true;
            secondHeart.enabled = false;
            thirdHeart.enabled = false;
        }
        else if (playerHP<=0)
        {
            firstHeart.enabled = false;
            secondHeart.enabled = false;
            thirdHeart.enabled = false;
        }
    }
}
