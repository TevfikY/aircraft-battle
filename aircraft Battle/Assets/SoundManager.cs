using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    private bool isMuted;

    [SerializeField] private AudioSource musicSource, effectSource;

    public static bool isButtonsMuted = false;
    public static bool isMusicMuted = false;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(effectSource);
        }

        else
        {
            Destroy(musicSource);
        }
        
    }

    private void Start()
    {
        checkIsMusicMuted();
        checkIsButtonsMuted();
    }

    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void ToggleEffects()
    {
        effectSource.mute = !effectSource.mute;
        if (!isButtonsMuted)
        {
            PlayerPrefs.SetInt("isButtonMuted",1);
            isButtonsMuted = true;
        }
        else
        {
            PlayerPrefs.SetInt("isButtonMuted",0);
            isButtonsMuted = false; 
        }
    }
    
    
    public void ToggleMusic()
    {
        //musicSource.mute = !musicSource.mute;
        if (!isMusicMuted)
        {
            PlayerPrefs.SetInt("isMusicMuted",1);
            isMusicMuted = true;
            musicSource.mute = true;
        }
        else
        {
            PlayerPrefs.SetInt("isMusicMuted",0);
            isMusicMuted = false;
            musicSource.mute = false;
        }
    }

    public void checkIsMusicMuted()
    {
        if (PlayerPrefs.GetInt("isMusicMuted") == 1)
        {
            musicSource.mute = true;
        }
        else
        {
            musicSource.mute = false;
        }
    }

    public void checkIsButtonsMuted()
    {
        if (PlayerPrefs.GetInt("isButtonMuted") == 1)
        {
            musicSource.mute = true;
        }
        else
        {
            musicSource.mute = false;
        }
    }
    
    
}