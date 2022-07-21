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
    
    // 0 is dmg Boost
    // 1 is HP boost
    // 2 double bullets
    // 3 hp regen
    private int firstUpgrade;
    private int secondUpgrade;
    private int thirdUpgrade;
    [SerializeField] private Button firstButton;
    [SerializeField]private Button secondButton;
    [SerializeField] private Button thirdButton;
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
        
        UpgradeList.Remove(UpgradeList[firstUpgrade]);
        secondUpgrade = UpgradeList[Random.Range(0, UpgradeList.Count)];
        
        UpgradeList.Remove(UpgradeList[secondUpgrade]);    
        thirdUpgrade = UpgradeList[Random.Range(0, UpgradeList.Count)];
        
        UpgradeList.Remove(UpgradeList[thirdUpgrade]);
        updateButtons();
    }

    void updateButtons()
    {
        firstButton.GetComponentInChildren<Text>().text = getUpgrade(firstUpgrade);
        secondButton.GetComponentInChildren<Text>().text = getUpgrade(secondUpgrade);
        thirdButton.GetComponentInChildren<Text>().text = getUpgrade(thirdUpgrade);
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
                textOnButton = "hp regen"; break;
            case 2: 
                textOnButton = "Dubble Bullets"; break;
            case 3: 
                textOnButton = "max hp boost"; break;
                
           
        }

        return textOnButton;
    }

    private void updateUpgradeList()
    {
        UpgradeList.Clear();
        UpgradeList.Add(0);
        UpgradeList.Add(1);
        UpgradeList.Add(2);
        UpgradeList.Add(3);
        
    }

    public void button1Action()
    {
        int upgrade = firstUpgrade;
        switch (upgrade)
        {
            case 0: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().updatePlayerDamage(2);
                 break;
            case 1: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().playerHeal(6);
                 break;
            case 2: 
                 break;
            case 3: 
                 break;
        }
        Time.timeScale = 1;
        closeMenu();
        

    }
    public void button2Action()
    {
        int upgrade = secondUpgrade;
        switch (upgrade)
        {
            case 0: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().updatePlayerDamage(2);
                break;
            case 1: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().playerHeal(6);
                break;
            case 2: 
                break;
            case 3: 
                break;
        }
        Time.timeScale = 1;
        closeMenu();
        
    }
    public void button3Action()
    {
        int upgrade = thirdUpgrade;
        switch (upgrade)
        {
            case 0: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().updatePlayerDamage(2);
                break;
            case 1: FindObjectOfType<PlayerStats>().gameObject.GetComponent<PlayerStats>().playerHeal(6);
                break;
            case 2: 
                break;
            case 3: 
                break;
        }
        Time.timeScale = 1;
        closeMenu();
        
    }

    

    
}
