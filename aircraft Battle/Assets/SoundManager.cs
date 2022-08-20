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

    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void ToggleEffects()
    {
        effectSource.mute = !effectSource.mute;
    }
    
    
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    
}