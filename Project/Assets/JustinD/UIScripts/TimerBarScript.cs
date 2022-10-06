using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBarScript : MonoBehaviour
{
    public Slider slider;
    
    // set the initial time for bar
    public void startTime(int startTime)
    {
        slider.maxValue = startTime;
        slider.value = startTime;
    }
    
    // change the time on the slider
    public void changeTime(int time)
    {
        slider.value = time;
    }
}
