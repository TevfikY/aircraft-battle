using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private float Score;
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(float score)
    {
        Score += score;
        scoreText.text = Score.ToString();
    }
    
    
}
