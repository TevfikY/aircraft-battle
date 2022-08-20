using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gameOver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audio;
    void Start()
    {
        audio.pitch = 0.40f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        audio.pitch = 1f;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void ReturnToMainMenu()
    {
        audio.pitch = 1f;
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
