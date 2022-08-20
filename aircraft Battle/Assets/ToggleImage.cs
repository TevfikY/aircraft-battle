using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImage : MonoBehaviour
{
   [SerializeField] private Sprite[] buttonSprites;
   
   [SerializeField] private Image targetButton;

   private void Awake()
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

      if (PlayerPrefs.GetInt("isButtonMuted") == 0)
      {
         targetButton.sprite = buttonSprites[0];
      }
      else
      {
         targetButton.sprite = buttonSprites[1];
      }
   }
   
}
