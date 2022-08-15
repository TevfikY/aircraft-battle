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
    [SerializeField] private Image firstHeart;
    [SerializeField] private Image secondHeart;
    [SerializeField] private Image thirdHeart;
    [SerializeField] private float maxHPincreasingAmount = 6;
    private static bool isBarrierOn = false;
    private static float barrierHP = 3;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI bestScore;
    
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
                FindObjectOfType<barrier>().GetComponent<barrier>().disableBarrier();
                barrierHP = 3;

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
