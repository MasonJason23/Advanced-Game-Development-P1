using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GamePhase
{
    START, // Loading phase
    PLAYERTURN, // Player decision
    BOATPHASE, // Sailboat reacts to player decision
    END // Game ends after time limit or casualty
}

public class GameManager : MonoBehaviour
{
    // Game state
    public GamePhase state = GamePhase.START;

    // UI reference
    public TextMeshProUGUI gameStateText;
    public TextMeshProUGUI gameTimerText;
    public TextMeshProUGUI playerTimerText;

    public float gameTimeLimit = 60f;
    public float playerTimeLimit = 10f;

    /*
     * <summary> C# event in which is invoke when the game state changes </summary>
     * <param name=gamePhase> Current game state (GamePhase) </param>
     * <returns> Nothing </returns>
     * Note* GameObjects must be subscribed to this event in order to actually be commanded by the GameManager
     */ 
    public event Action<GamePhase> changePhase;

    // Start is called before the first frame update
    private void Start()
    {
        // Instantiates game objects and UI, nothing implemented atm
        SetupPlayingField();
        
        // Missing UI reference
        if (!gameStateText)
        {
            Debug.Log("Missing reference component");
        }
        
        // Initialize UI text
        ChangeGameStateText(state);
        playerTimerText.text = playerTimeLimit.ToString("F1");
        gameTimerText.text = gameTimeLimit.ToString("F1");
    }

    private void Update()
    {
        // Ends the game
        if (state == GamePhase.END)
        {
            return;
        }
        
        // Check time to make sure to change to next phase
        if (playerTimeLimit <= 0.09f)
        {
            StartNextPhase();
        }

        // Temporary: reset game timer once "reaching" zero
        // TODO: End the game when game timer reaches zero
        if (gameTimeLimit <= 0.09f) gameTimeLimit = 60f;

        // Count down based on Time.deltaTime
        gameTimeLimit -= Time.deltaTime;
        gameTimerText.text = gameTimeLimit.ToString("F1");
        playerTimeLimit -= Time.deltaTime;
        playerTimerText.text = playerTimeLimit.ToString("F1");
    }

    // Used to literally set the playing field.
    void SetupPlayingField()
    {
        /* TODO
         * Play loading screen (UI element)
         * While the loading screen is active:
         *      - spawn player in a semi-random position on the map
         *      - instantiate game objects & UI into the game
         */

        // After setting up game area, player is immediately given their "turn" to play.
        state = GamePhase.PLAYERTURN;
    }
    
    // Function is also used by a UI button to start the BoatPhase
    public void StartNextPhase()
    {
        // Switch game state to other phase based on current game state
        if (state == GamePhase.PLAYERTURN)
            state = GamePhase.BOATPHASE;
        else if (state == GamePhase.BOATPHASE) state = GamePhase.PLAYERTURN;

        // Change UI text
        ChangeGameStateText(state);

        // Invoke event
        changePhase?.Invoke(state);

        // Reset player time
        playerTimeLimit = 10f;
    }

    // Changing UI text based on game state
    void ChangeGameStateText(GamePhase state)
    {
        if (state == GamePhase.PLAYERTURN) gameStateText.text = "Player Turn Phase";
        else if (state == GamePhase.BOATPHASE) gameStateText.text = "Sailboat Phase";
        else if (state == GamePhase.END) gameStateText.text = "Game Over";
    }
}
