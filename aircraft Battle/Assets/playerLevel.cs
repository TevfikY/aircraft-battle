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

    private void openUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
        Time.timeScale = 0;
        firstUpgrade = Random.Range(0, UpgradeList.Count);
        UpgradesOnScreen.Add(firstUpgrade);
        UpgradeList.Remove(firstUpgrade);
        secondUpgrade = Random.Range(0, UpgradeList.Count);
        UpgradesOnScreen.Add(secondUpgrade);
        UpgradeList.Remove(secondUpgrade);    
        thirdUpgrade = Random.Range(0, UpgradeList.Count);
        UpgradesOnScreen.Add(thirdUpgrade);
        UpgradeList.Remove(thirdUpgrade); 
    }

    private void updateUpgradeList()
    {
        UpgradeList.Add(0);
        UpgradeList.Add(1);
        UpgradeList.Add(2);
        UpgradeList.Add(3);
        
    }

    private void updateButons(int first,int second,int third)
    {
        
    }
}
