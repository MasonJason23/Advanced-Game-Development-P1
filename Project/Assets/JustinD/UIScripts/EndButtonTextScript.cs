using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndButtonTextScript : MonoBehaviour
{
    [SerializeField] TMP_Text endText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void changeColors(int newRed, int newBlue, int newGreen, int newAlpha)
    {
        endText.color = new Color(newRed, newBlue, newGreen, newAlpha);
    }
}
