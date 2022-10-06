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
	//public MovementTurnPopupScript movementPop;

    // Not in use at the moment
    // public EndButtonTextScript endText;
	// public EndButtonScript endButton;

	// tells if its the player's turn or not
    private bool playerTurn = false;

	//animations
	public string movementPopUp;
	public string playerPopUp;
	public PlayerTurnPopupScript playerPop;
	private bool hasSwitched;
    
    // Strings used by Justin
    const string playerPhase = "Player's Turn";
    const string boatPhase = "Movement Turn";
    
    // keeps track of time on the current turn
    private float turnCounter;

    private bool gameEnd = false;

    // starting time for the game
    [SerializeField] float totalTime = 90.0f;
    
    void Start()
    {
	    // Subscribing to GameManager Event
	    GameManager.GmInstance.changePhase += UpdateCurrentState;
	    
	    // set the initial time to healthbar
        timeBar.startTime((int)GameManager.GmInstance.playerHealth);

        // set round time
        turnCounter = GameManager.GmInstance.playerTimeLimit;
    }

    // Update is called once per frame
    void Update()
    {
	    // UI shouldn't do anything else when game ends
	    if (gameEnd) return;

	    // turnCounter gets "turnCounter" from GameManager
        turnCounter = GameManager.GmInstance.currentPlayerTL;

		if (turnCounter > 0.09f)
		{
			hasSwitched = false;
		}

        // if the turn ends
        if (turnCounter <= 0.09f && hasSwitched == false)
        {
			hasSwitched = true;
            // if its the movement turn when round ends
            if (!playerTurn)
            {
	            // change the turn
                whoseTurn.newTurn(playerPhase);
                whoseTurn.changeColors(0, 255, 255, 255);

				// add animations
				playerPop.PopUp("Player Turn");
				
                // Implementation needs rework
                // endText.changeColors(0, 0, 0, 255);
				// endButton.becomeUninteractable();
            }

            // if its the players turn when the round ends
            else
            {
	            // change the turn
                whoseTurn.newTurn(boatPhase);
                whoseTurn.changeColors(255, 255, 0, 255);
                
				// add animations
				//movementPop.PopUp();
				playerPop.PopUp("Movement Turn");
				
                // Implementation needs rework
				// endText.changeColors(255, 255, 255, 255);
				// endButton.becomeInteractable();
            }

            // reset round time using the GameManager's turn time
            turnCounter = GameManager.GmInstance.playerTimeLimit;
        }

        // update the UI timer via GameManager
        timer.changeTimer(GameManager.GmInstance.currentPlayerTL);

        // when its not the player's turn
        if (!playerTurn)
        {
            // change the healthbar via GameManager
            totalTime = GameManager.GmInstance.playerHealth;
            int tempTime = Mathf.RoundToInt(totalTime);
            timeBar.changeTime(tempTime);
        }
    }

    // UI shouldn't have control over the game's phase (Function To Be Deleted)
	// public void endTurn(){
	// 	playerTurn = false;
	// 	whoseTurn.newTurn("Movement Turn");
	// 	whoseTurn.changeColors(255, 255, 0, 255);
	// 	endText.changeColors(255, 255, 255, 255);
	// 	endButton.becomeUninteractable();
	// 	turnCounter = 10.0f;
	// 	timer.changeTimer(turnCounter);
	// }

	// Function tied to a GameManager event (Jason)
	// Gets the game's current phase either by turn time reaches zero or player presses "End Turn" button
	void UpdateCurrentState(GamePhase state)
	{
		if (state == GamePhase.BOATPHASE)
		{
			playerTurn = false;
			whoseTurn.newTurn(boatPhase);
		}
		else if (state == GamePhase.PLAYERTURN)
		{
			playerTurn = true;
			whoseTurn.newTurn(playerPhase);
		}
		else if (state == GamePhase.END)
		{
			gameEnd = true;
		}
	}
}
