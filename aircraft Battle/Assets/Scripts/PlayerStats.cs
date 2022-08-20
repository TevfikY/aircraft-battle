using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Button pauseButton;
    [SerializeField] private float playerHP;
    [SerializeField] private float playerDamage;
    
    [SerializeField] private float maxHPincreasingAmount = 6;
    private static bool isBarrierOn = false;
    private static float barrierHP = 3;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private Image hpBar;
    
    
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
        
        if (!isBarrierOn)
        {
            int dmf;
            playerHP = playerHP - damage;
            hpBar.fillAmount = playerHP / maxHP;
            if (playerHP <= 0)
            {
                
                
                if (PlayerPrefs.HasKey("playerScore"))
                {
                    if (PlayerPrefs.GetFloat("playerScore") < GetComponent<playerLevel>().getScore())
                    {
                        PlayerPrefs.SetFloat("playerScore",GetComponent<playerLevel>().getScore());
                    }
                }
                else
                {
                    PlayerPrefs.SetFloat("playerScore",GetComponent<playerLevel>().getScore());
                }
                currentScore.text = GetComponent<playerLevel>().getScore().ToString();
                GetComponent<playerLevel>().resetScore();
                bestScore.text = PlayerPrefs.GetFloat("playerScore").ToString();
                
                Time.timeScale = 0;
                gameOver.SetActive(true);
                pauseButton.enabled = false;
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
                FindObjectOfType<barrier>().GetComponent<barrier>().disableBarrier();
                barrierHP = 3;

            }
        }
        
            
            
        
    }

    public void playerHeal(float hp)
    {
        playerHP += hp;
        if (playerHP > maxHP) playerHP = maxHP;
        playerGetHit(0);
    }

    public void updatePlayerDamage(float damage)
    {
        playerDamage += damage;
    }

    public void updatePlayerHp()
    {
        maxHP += 5;
        playerHP += 5;
    }

    public float getDamage()
    {
        return playerDamage;
    }

    public void increaseMaxHP()
    {
        maxHP += maxHPincreasingAmount;
        playerHP += 6;
        playerGetHit(0);
    }

    public void setBarrierOn()
    {
        isBarrierOn = true;
    }

    public bool checkIsBarrierOn()
    {
        return isBarrierOn;
    }
}
