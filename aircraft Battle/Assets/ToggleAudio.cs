using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool toggleMusic, toggleEffects;

    public void Toggle()
    {
        if(toggleEffects) SoundManager.Instance.ToggleEffects();
        if(toggleMusic) SoundManager.Instance.ToggleMusic();
    }
}
