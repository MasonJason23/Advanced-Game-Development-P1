using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelSliderScript : MonoBehaviour
{
    public Slider slider;
    //RectTransform rectTransform;

    private float wheelRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        //rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        wheelRotation = slider.value * -5;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, wheelRotation);
    }
}
