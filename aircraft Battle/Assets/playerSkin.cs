using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSkin : MonoBehaviour
{
    [SerializeField] private List<Sprite> playerSkins;
    private int selectedSkin;
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
       selectedSkin = PlayerPrefs.GetInt("selectedCharacter");
       switch (selectedSkin)
       {
           case 0: sr.sprite = playerSkins[0]; break;
           case 1: sr.sprite = playerSkins[1]; break;
           case 2: sr.sprite = playerSkins[2]; break;
           
           default: sr.sprite = playerSkins[0]; break;
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
