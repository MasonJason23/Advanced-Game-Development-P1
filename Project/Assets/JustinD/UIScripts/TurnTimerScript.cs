using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnTimerScript : MonoBehaviour
{
    private float timeRemaining = 0f;
    public TMP_Text timerText;

    void Update()
    {
        timerText.text = "TURN TIME: " + timeRemaining.ToString("F0");
    }

    public void changeTimer(float newTime)
    {
        timeRemaining = newTime;
    }
}
