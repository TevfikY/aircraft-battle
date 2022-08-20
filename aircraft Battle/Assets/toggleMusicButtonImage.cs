using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleMusicButtonImage : MonoBehaviour
{
    [SerializeField] private Sprite[] buttonSprites;
   
    [SerializeField] private Image targetButton;

    

    private void Start()
    {
        ChangeSprite();
    }

    public void ChangeSprite()
    {
        /*if (targetButton.sprite == buttonSprites[0]) 
        {
           targetButton.sprite = buttonSprites[1];
           return;
        }
        
        targetButton.sprite = buttonSprites[0];
        */

        if (PlayerPrefs.GetInt("isMusicMuted") == 0)
        {
            targetButton.sprite = buttonSprites[0];
            
        }
        else
        {
            targetButton.sprite = buttonSprites[1];
            
        }
    }
}
