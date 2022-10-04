using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CanvasKeeperScript : MonoBehaviour
{
    // This script manages the values for the other UI scripts
    
    // UI elements that the script controls
    public TimerBarScript timeBar;
    public TurnTimerScript timer;
    public WhoseTurnScript whoseTurn;
	public EndButtonTextScript endText;
	public EndButtonScript endButton;

	// tells if its the player's turn or not
    private bool playerTurn = false;
    
    // keeps track of time on the current turn
    private float turnCounter;

    // starting time for the game
    [SerializeField] float totalTime = 90.0f;
    
    void Start()
    {
        // set the initial time to healthbar
        timeBar.startTime(90);

        // set round time
        turnCounter = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // decrease the counter by time
        turnCounter -= Time.deltaTime;

        // if the turn ends
        if (turnCounter <= 0)
        {
            // if its the movement turn when round ends
            if (!playerTurn)
            {
	            // change the turn
                playerTurn = true;
                whoseTurn.newTurn("Player's Turn");
                whoseTurn.changeColors(0, 255, 255, 255);
				endText.changeColors(0, 0, 0, 255);
				endButton.becomeUninteractable();
            }

            // if its the players turn when the round ends
            else
            {
	            // change the turn
                playerTurn = false;
                whoseTurn.newTurn("Movement Turn");
                whoseTurn.changeColors(255, 255, 0, 255);
				endText.changeColors(255, 255, 255, 255);
				endButton.becomeInteractable();
            }

            // reset round time
            turnCounter = 10.0f;
        }

        // update the UI timer
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

    // when the player pushes the "END TURN" button
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
