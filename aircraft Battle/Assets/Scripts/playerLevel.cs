using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLevel : MonoBehaviour
{
    
    private float playerCurrentExp = 0;
    private float maxExp = 100;
    [SerializeField] Image expBar;
    private int playerLvl = 1;
    [SerializeField] private Text lvlText;
    [SerializeField] GameObject upgradeMenu;
    private List<int> UpgradeList = new List<int>(); 
    private List<int> SpecialUpgradeList = new List<int>();
    private static int currentTurretForm = 0;
    // 0 is dmg Boost
    // 1 is HP boost
    // 2 double bullets
    // 3 increase max HP
    // 4 increase turret size
     static int firstUpgrade;
     static int secondUpgrade;
     static int thirdUpgrade;
    [SerializeField] private Button firstButton;
    [SerializeField]private Button secondButton;
    [SerializeField] private Button thirdButton;
    private int selectedUpgrade;
    private static bool isDoubleBullet = false;
    
    
    
    void Start()
    {
        expBar.fillAmount = playerCurrentExp / maxExp;
        lvlText.text = playerLvl.ToString();
        upgradeMenu.SetActive(false);
        updateUpgradeList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEXP(float exp)
    {
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
            
            
        }
        expBar.fillAmount = playerCurrentExp / maxExp;
    }

    public void closeMenu()
    {
        //upgradeMenu.SetActive(false);
        FindObjectOfType<lvltestempty>().gameObject.SetActive(false);
    }
    private void openUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
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
        firstButton.GetComponentInChildren<Text>().text = getUpgrade(firstUpgrade);
        secondButton.GetComponentInChildren<Text>().text = getUpgrade(secondUpgrade);
        thirdButton.GetComponentInChildren<Text>().text = getUpgrade(thirdUpgrade);
        
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
                
           
        }

        return textOnButton;
    }

    private void updateUpgradeList()
    {
        Debug.Log(isDoubleBullet);
        UpgradeList.Add(0);
        UpgradeList.Add(1);
        //UpgradeList.Add(2);
        UpgradeList.Add(3);
        //UpgradeList.Add(4);
        if (!isDoubleBullet && currentTurretForm < 3)
        {
            SpecialUpgradeList.Add(2);
            SpecialUpgradeList.Add(3);
            SpecialUpgradeList.Add(1);
            SpecialUpgradeList.Add(4);
        }
        else if(isDoubleBullet && currentTurretForm <3)
        {
            Debug.Log("2. if");
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
            case 1: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().playerHeal(6);
                break;
            case 2: FindObjectOfType<PlayerStats>().gameObject.GetComponent<playerShooting>().changeBulletType(1);
                isDoubleBullet = true;
                break;
            case 3: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().increaseMaxHP();
                break;
            case 4: FindObjectOfType<playerShooting>().gameObject.GetComponent<playerShooting>().increaseTurretCount();
                currentTurretForm++;
                break;
            
        }

       
        Time.timeScale = 1;
        closeMenu();
    }

   

    

    
}
