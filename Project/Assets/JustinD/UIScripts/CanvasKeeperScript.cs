using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CanvasKeeperScript : MonoBehaviour
{
    // This script manages the values for the other UI scripts
    public TimerBarScript timeBar;
    public TurnTimerScript timer;
    public WhoseTurnScript whoseTurn;
	public EndButtonTextScript endText;
	public EndButtonScript endButton;

    private bool playerTurn = false;
    private float turnCounter;

    [SerializeField] float totalTime = 90.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // set the initial time to healthbar
        timeBar.startTime(90);

        turnCounter = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // increment the counter
        turnCounter -= Time.deltaTime;

        // if the turn counter changes
        if (turnCounter <= 0)
        {
            // change the turn
            if (!playerTurn)
            {
                playerTurn = true;
                whoseTurn.newTurn("Player's Turn");
                whoseTurn.changeColors(0, 255, 255, 255);
				endText.changeColors(0, 0, 0, 255);
				endButton.becomeUninteractable();
            }

            else
            {
                playerTurn = false;
                whoseTurn.newTurn("Movement Turn");
                whoseTurn.changeColors(255, 255, 0, 255);
				endText.changeColors(255, 255, 255, 255);
				endButton.becomeInteractable();
            }

            turnCounter = 10.0f;
        }

        timer.changeTimer(turnCounter);
        
        
        // when its not the player's turn
        if (!playerTurn)
        {
            // change the healthbar
            totalTime -= Time.deltaTime;
            int tempTime = Mathf.RoundToInt(totalTime);
            timeBar.changeTime(tempTime);
        }
    }

	public void endTurn(){
		
		playerTurn = false;
        whoseTurn.newTurn("Movement Turn");
        whoseTurn.changeColors(255, 255, 0, 255);
		endText.changeColors(255, 255, 255, 255);
		endButton.becomeUninteractable();
		turnCounter = 10.0f;
		timer.changeTimer(turnCounter);
	}
}
