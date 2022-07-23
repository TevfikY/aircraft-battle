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
    [SerializeField] private float maxHPincreasingAmount = 6;
    private bool isBarrierOn = false;
    private float barrierHP = 10;
    
    private float maxHP;
    void Start()
    {
        maxHP = playerHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerGetHit(float damage)
    {
        Debug.Log(isBarrierOn);
        if (!isBarrierOn)
        {
            int dmf;
            playerHP = playerHP - damage;
            if(playerHP<=0) Time.timeScale = 0;
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
            else if (playerHP / maxHP > (1 / 12f))
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
        else if (isBarrierOn)
        {
            if (barrierHP - damage > 0)
            {
                Debug.Log("barrier damage "+barrierHP );
                barrierHP -= damage;
            }
            else
            {
                isBarrierOn = false;
                GetComponent<barrier>().disableBarrier();
                
            }
        }
        
            
            
        
    }

    public void playerHeal(float hp)
    {
        playerHP += hp;
        if (playerHP > maxHP) playerHP = maxHP;
    }

    public void updatePlayerDamage(float damage)
    {
        playerDamage += damage;
    }

    public float getDamage()
    {
        return playerDamage;
    }

    public void increaseMaxHP()
    {
        maxHP += maxHPincreasingAmount;
    }

    public void setBarrierOn()
    {
        isBarrierOn = true;
    }
}
