using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    private int score;
    [SerializeField] TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreText.text = "Score: " + score.ToString();
    }

    void addScore()
    {
        score++;
    }
}
