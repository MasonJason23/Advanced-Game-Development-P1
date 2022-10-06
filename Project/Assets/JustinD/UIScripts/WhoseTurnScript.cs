using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WhoseTurnScript : MonoBehaviour
{
    [SerializeField] TMP_Text turnText;
    private string currentPlayer;

    void Start()
    {
        currentPlayer = "Movement Turn";
        turnText.color = new Color(255, 255, 0, 255);
    }
    
    void Update()
    {
        turnText.text = currentPlayer;
    }

    public void newTurn(string who)
    {
        currentPlayer = who;
    }

    public void changeColors(int newRed, int newBlue, int newGreen, int newAlpha)
    {
        turnText.color = new Color(newRed, newBlue, newGreen, newAlpha);
    }

}
