using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnTimerScript : MonoBehaviour
{
    [SerializeField] float startingTime = 10.0f;
    private float timeRemaining;

    [SerializeField] TMP_Text timerText;

    void Start()
    {
        timeRemaining = startingTime;
    }
    
    void Update()
    {
        timerText.text = "TURN TIME: " + timeRemaining.ToString("F0");
    }

    public void changeTimer(float newTime)
    {
        timeRemaining = newTime;
    }
}
