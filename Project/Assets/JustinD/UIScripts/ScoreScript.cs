using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    private int score;
    [SerializeField] TMP_Text scoreText;
    void Start()
    {
        score = 0;
    }
    
    void Update()
    {
        
        scoreText.text = "Score: " + score.ToString();
    }

    void addScore()
    {
        score++;
    }
}
