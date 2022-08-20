using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour

{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] private AudioSource audio;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        audio.pitch = 0.59f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }


}