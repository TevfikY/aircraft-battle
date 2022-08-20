using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField ]private AudioSource playMusic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        Debug.Log(PlayerPrefs.GetInt("isButtonMuted"));
        if (PlayerPrefs.GetInt("isButtonMuted") == 0)
        {
            playMusic.Play();  
        }
        
    }
}
