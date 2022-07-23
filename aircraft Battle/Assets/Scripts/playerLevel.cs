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
    private List<int> UpgradesOnScreen = new List<int>(); 
    // 0 is dmg Boost
    // 1 is HP boost
    // 2 double bullets
    // 3 hp regen
     static int firstUpgrade;
     static int secondUpgrade;
     static int thirdUpgrade;
    [SerializeField] private Button firstButton;
    [SerializeField]private Button secondButton;
    [SerializeField] private Button thirdButton;
    private int copy1;
    private int copy2;
    private int copy3;
    private int test = 11;
    
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
        
        if (playerCurrentExp >= maxExp)
        {
            playerLvl++;
            lvlText.text = playerLvl.ToString();
            playerCurrentExp -= maxExp;
            openUpgradeMenu();
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
        Debug.Log("openUpgrade");
        Debug.Log(firstUpgrade);
        Debug.Log(secondUpgrade);
        Debug.Log(thirdUpgrade);
        //UpgradeList.Remove(thirdUpgrade);
        updateButtons();
    }

    void updateButtons()
    {
        Debug.Log("updateButtons");
        Debug.Log(firstUpgrade);
        Debug.Log(secondUpgrade);
        Debug.Log(thirdUpgrade);
        
        //UpgradeList.Remove(thirdUpgrade);
        firstButton.GetComponentInChildren<Text>().text = getUpgrade(firstUpgrade);
        secondButton.GetComponentInChildren<Text>().text = getUpgrade(secondUpgrade);
        thirdButton.GetComponentInChildren<Text>().text = getUpgrade(thirdUpgrade);
        
        UpgradeList.Clear();
        updateUpgradeList();
    }
    
    string getUpgrade(int up)
    {
        Debug.Log("getUpgrade" );
        Debug.Log(firstUpgrade);
        Debug.Log(secondUpgrade);
        Debug.Log(thirdUpgrade);
        copy1 = firstUpgrade;
        copy2 = secondUpgrade;
        copy3 = thirdUpgrade;
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
                
           
        }

        return textOnButton;
    }

    private void updateUpgradeList()
    {
        UpgradeList.Add(0);
        UpgradeList.Add(1);
        UpgradeList.Add(2);
        UpgradeList.Add(3);
        
    }

    public void button1Action()
    {
        Debug.Log("Button1Action");
        Debug.Log(copy1);
        Debug.Log(copy2);
        Debug.Log(copy3);
        
        
        int button1Upgrade = firstUpgrade;
        
        Debug.Log(button1Upgrade);
        switch (button1Upgrade)
        {
            case 0: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().updatePlayerDamage(2);
                 break;
            case 1: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().playerHeal(6);
                 break;
            case 2: Debug.Log("case double bullet"); 
                FindObjectOfType<PlayerStats>().gameObject.GetComponent<playerShooting>().changeBulletType(1);
                
                 break;
            case 3: 
                 break;
        }
        Time.timeScale = 1;
        closeMenu();
        
    }
    public void button2Action()
    {
        Debug.Log("Button1Action");
        Debug.Log(copy1);
        Debug.Log(copy2);
        Debug.Log(copy3);
        
        
        int button1Upgrade = secondUpgrade;
        
        Debug.Log(button1Upgrade);
        switch (button1Upgrade)
        {
            case 0: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().updatePlayerDamage(2);
                break;
            case 1: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().playerHeal(6);
                break;
            case 2: Debug.Log("case double bullet"); 
                FindObjectOfType<PlayerStats>().gameObject.GetComponent<playerShooting>().changeBulletType(1);
                
                break;
            case 3: 
                break;
        }
        Time.timeScale = 1;
        closeMenu();
        
    }
    public void button3Action()
    {
        Debug.Log("Button1Action");
        Debug.Log(copy1);
        Debug.Log(copy2);
        Debug.Log(copy3);
        
        
        int button1Upgrade = thirdUpgrade;
        
        Debug.Log(button1Upgrade);
        switch (button1Upgrade)
        {
            case 0: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().updatePlayerDamage(2);
                break;
            case 1: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().playerHeal(6);
                break;
            case 2: Debug.Log("case double bullet"); 
                FindObjectOfType<PlayerStats>().gameObject.GetComponent<playerShooting>().changeBulletType(1);
                
                break;
            case 3: 
                break;
        }
        Time.timeScale = 1;
        closeMenu();
        
    }

   

    

    
}
