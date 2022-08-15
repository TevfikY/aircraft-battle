using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLevel : MonoBehaviour
{
    
    [SerializeField] private GameObject armour;
    private float playerCurrentExp = 0;
    private float maxExp = 100;
    [SerializeField] Image expBar;
    private int playerLvl = 1;
    [SerializeField] private Text lvlText;
    [SerializeField] GameObject upgradeMenu;
    private List<int> UpgradeList = new List<int>(); 
    private List<int> SpecialUpgradeList = new List<int>();
    private static int currentTurretForm = 0;
    [SerializeField] private Sprite healthImage;
    [SerializeField] private Sprite healthMax;
    [SerializeField] private Sprite barrier;
    [SerializeField] private Sprite doubleBullet;
    [SerializeField] private Sprite turretCount2;
    [SerializeField] private Sprite turretCount3;
    [SerializeField] private Sprite damageBoost;
    // 0 is dmg Boost
    // 1 is HP boost
    // 2 double bullets
    // 3 increase max HP
    // 4 increase turret size
    // 5 barrier
     static int firstUpgrade;
     static int secondUpgrade;
     static int thirdUpgrade;
    [SerializeField] private Button firstButton;
    [SerializeField]private Button secondButton;
    [SerializeField] private Button thirdButton;
    [SerializeField] private List<Sprite> redSkins;
    [SerializeField] private List<Sprite> greenSkins;
    [SerializeField] private List<Sprite> yellowSkins;
    [SerializeField] private  Button pauseButton;
    private int selectedUpgrade;
    private static bool isDoubleBullet = false;
    private int selectedCharacter;
    private SpriteRenderer sr;
    private static float playerScore = 0;
    
    
    void Start()
    {
        expBar.fillAmount = playerCurrentExp / maxExp;
        lvlText.text = playerLvl.ToString();
        upgradeMenu.SetActive(false);
        updateUpgradeList();
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEXP(float exp)
    {
        playerScore += exp;
        playerCurrentExp += exp;
        GetComponent<playerScore>().updateScore(exp);
        if (playerCurrentExp >= maxExp)
        {
            
            playerLvl++;
            lvlText.text = playerLvl.ToString();
            playerCurrentExp -= maxExp;
            if (playerLvl % 3 == 0)
            {
                Debug.Log("working");
                openSpecialUpgradeMenu();
            }
            else
            {
                openUpgradeMenu(); 
            }
            changePlane(playerLvl);
            
        }
        expBar.fillAmount = playerCurrentExp / maxExp;
    }

    public void closeMenu()
    {
        //upgradeMenu.SetActive(false);
        FindObjectOfType<lvltestempty>().gameObject.SetActive(false);
        FindObjectOfType<buttonFinder>().gameObject.GetComponent<Image>().enabled = true;
    }
    private void openUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
        FindObjectOfType<buttonFinder>().gameObject.GetComponent<Image>().enabled = false;
        Time.timeScale = 0;
        firstUpgrade = UpgradeList[Random.Range(0, UpgradeList.Count)];
        
        UpgradeList.Remove(firstUpgrade);
        secondUpgrade = UpgradeList[Random.Range(0, UpgradeList.Count)];
        
        UpgradeList.Remove(secondUpgrade);    
        thirdUpgrade = UpgradeList[Random.Range(0, UpgradeList.Count)];
        //UpgradeList.Remove(thirdUpgrade);
        updateButtons();
    }

    void openSpecialUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
        FindObjectOfType<buttonFinder>().gameObject.GetComponent<Image>().enabled = false;
        Time.timeScale = 0;
        Debug.Log(SpecialUpgradeList.Count);
        firstUpgrade = SpecialUpgradeList[Random.Range(0, SpecialUpgradeList.Count)];
        SpecialUpgradeList.Remove(firstUpgrade);

        secondUpgrade = SpecialUpgradeList[Random.Range(0, SpecialUpgradeList.Count)];
        
        SpecialUpgradeList.Remove(secondUpgrade);  
        thirdUpgrade = SpecialUpgradeList[Random.Range(0, SpecialUpgradeList.Count)];
        SpecialUpgradeList.Remove(thirdUpgrade);
        updateButtons();
    }

    void updateButtons()
    {
        
        //UpgradeList.Remove(thirdUpgrade);

        firstButton.GetComponent<Image>().sprite = getSprite(firstUpgrade);
        secondButton.GetComponent<Image>().sprite = getSprite(secondUpgrade);
        thirdButton.GetComponent<Image>().sprite = getSprite(thirdUpgrade);
        UpgradeList.Clear();
        SpecialUpgradeList.Clear();
        updateUpgradeList();
    }
    
    string getUpgrade(int up)
    {
        
        int upgrade = up;
        string textOnButton = " ";
        switch (upgrade)
        {
            case 0: 
                textOnButton = "dmg Boost"; break;
            case 1: 
                textOnButton = "hp boost"; break;
            case 2: 
                textOnButton = "Dubble Bullets"; break;
            case 3: 
                textOnButton = "max hp boost"; break;
            case 4:
                textOnButton = "increase turret count"; break;
            case 5:
                textOnButton = "barrier"; break;
                
           
        }

        return textOnButton;
    }

    Sprite getSprite(int up)
    {
        int upgrade = up;
        Sprite buttonSprite = healthImage;
        switch (upgrade)
        {
            case 0:
                buttonSprite = damageBoost;
                break;
            case 1:
                buttonSprite = healthImage;
                break;
            case 2:
                buttonSprite = doubleBullet;
                break;
            case 3:
                buttonSprite = healthMax;
                break;
            case 4:

                if (currentTurretForm < 1) buttonSprite = turretCount2;
                else
                {
                    buttonSprite = turretCount3;
                }
                break;
            case 5: buttonSprite = barrier;
                break;
                
           
        }

        return buttonSprite;
    }
    // 0 is dmg Boost
    // 1 is HP boost
    // 2 double bullets
    // 3 increase max HP
    // 4 increase turret size
    // 5 barrier

    private void updateUpgradeList()
    {
        
        UpgradeList.Add(0);
        UpgradeList.Add(1);
        //UpgradeList.Add(2);
        UpgradeList.Add(3);
        UpgradeList.Add(5);
        //UpgradeList.Add(4);
        if (!isDoubleBullet && currentTurretForm < 2)
        {
            SpecialUpgradeList.Add(2);
            SpecialUpgradeList.Add(3);
            SpecialUpgradeList.Add(1);
            SpecialUpgradeList.Add(4);
        }
        else if (!isDoubleBullet && currentTurretForm == 2)
        {
            SpecialUpgradeList.Add(2);
            SpecialUpgradeList.Add(3);
            SpecialUpgradeList.Add(1);
            
        }
        else if(isDoubleBullet && currentTurretForm <2)
        {
            
            SpecialUpgradeList.Add(3);
            SpecialUpgradeList.Add(0);
            //SpecialUpgradeList.Add(1);
            SpecialUpgradeList.Add(4);
        }
        else
        {
            
            SpecialUpgradeList.Add(0);
            SpecialUpgradeList.Add(1);
            SpecialUpgradeList.Add(3);
        }
        
        
    }

    public void button1Action()
    {
        buttonActionMenu(firstUpgrade);
    }
    public void button2Action()
    {
        buttonActionMenu(secondUpgrade);
    }
    public void button3Action()
    {
        buttonActionMenu(thirdUpgrade);
    }

    void buttonActionMenu(int upgrade)
    {
        int buttonUpgrade = upgrade;
        selectedUpgrade = buttonUpgrade;
       
        switch (buttonUpgrade)
        {
            case 0: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().updatePlayerDamage(2);
                break;
            case 1: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().playerHeal(10);
                break;
            case 2: FindObjectOfType<PlayerStats>().gameObject.GetComponent<playerShooting>().changeBulletType(1);
                isDoubleBullet = true;
                break;
            case 3: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().increaseMaxHP();
                break;
            case 4: FindObjectOfType<playerShooting>().gameObject.GetComponent<playerShooting>().increaseTurretCount();
                currentTurretForm++;
                break; 
            case 5:
                Instantiate(armour, transform.position, transform.rotation);
                GetComponent<PlayerStats>().setBarrierOn();
                break;
                
            
        }

       
        Time.timeScale = 1;
        
        closeMenu();
    }

    void changePlane(int lvl)
    {
        if (lvl == 3)
        {
            if (selectedCharacter == 0)
            {
                sr.sprite = redSkins[0];
            }
            else if (selectedCharacter == 1)
            {
                sr.sprite = greenSkins[0];
            }
            else if (selectedCharacter == 2)
            {
                sr.sprite = yellowSkins[0];
            }
        }
        else if (lvl == 6)
        {
            if (selectedCharacter == 0)
            {
                sr.sprite = redSkins[1];  
            }
            else if (selectedCharacter == 1)
            {
                sr.sprite = greenSkins[1];    
            }
            else if (selectedCharacter == 2)
            {
                sr.sprite = yellowSkins[1];    
            }
        }
        
    }

    public float getScore()
    {
        return playerScore;
    }

    public void resetScore()
    {
        playerScore = 0;
    }
    
   

    

    
}
