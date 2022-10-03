using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RotationNumberScript : MonoBehaviour
{
    public Slider slider;
    private int rotation;
    [SerializeField] TMP_Text rotateText;
    // Start is called before the first frame update
    void Start()
    {
        rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rotation = Mathf.RoundToInt(slider.value);
        rotateText.text = rotation.ToString();
    }
}
