using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelSliderScript : MonoBehaviour
{
    public Slider slider;
    private float wheelRotation;
    
    void Update()
    {
        wheelRotation = slider.value * -5;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, wheelRotation);
    }
}
