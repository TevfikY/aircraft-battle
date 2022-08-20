using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using Unity.VisualScripting;

public class MenuController : MonoBehaviour
{
    [Header("Volume Setting")] 
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;
    
    
    
    
    [Header("Confirmation")] 
    [SerializeField] private GameObject confirmationPrompt = null;
    
    
    [Header("Levels to Load")] 
    public string _newGamelevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    public void NewGameDialogYes()
    {  
        SceneManager.LoadScene(_newGamelevel);
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    public void changeVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("volume", newVolume);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        volumeTextValue.text = newVolume.ToString("0.0");
    }

    public void SetVolume(float volume)
    {
        
        AudioListener.volume = volume;
        //Debug.Log(AudioListener.volume);
        volumeTextValue.text = volume.ToString("0.0");
    }
    

    public void VolumeApply()
    {
        float newVolume = AudioListener.volume;
         
        PlayerPrefs.SetFloat("masterVolume", newVolume);
        PlayerPrefs.Save();
        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            VolumeApply();

        }
    }
    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
    
}
