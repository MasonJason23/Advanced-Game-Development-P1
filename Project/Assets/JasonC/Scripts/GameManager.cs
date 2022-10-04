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
    // Reference to UI
    public GameOverScreen gameOverScreen;
    public GameObject playerUI;
    
    // Reference to Animator
    public Animator transition;
    private static readonly int Transition = Animator.StringToHash("Transition");
    
    // Game state
    public GamePhase state = GamePhase.START;

    // UI reference
    public TextMeshProUGUI gameStateText;
    public TextMeshProUGUI gameScoreText;
    public TextMeshProUGUI playerTimerText;

    // Keep track of player's time limit and score
    public int gameScore = 0;
    public float playerTimeLimit = 10f;
    public float currentPlayerTL; 
    
    // Player Health (temporary)
    public float playerHealth = 100f;

    // Debug function
    public void EndGame()  {
        state = GamePhase.END;
        changePhase?.Invoke(state);
    }
    
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
    }

    private void Update()
    {
        // Ends the game
        if (state == GamePhase.END)
        {
            StartCoroutine(DisablePlayerUI());
            gameOverScreen.SetUp(gameScore);
            return;
        }
        
        // Check time to make sure to change to next phase
        if (currentPlayerTL <= 0.09f)
        {
            StartNextPhase();
        }

        // Temporary: reset player health when depleted
        // TODO: End the game when game timer reaches zero
        if (playerHealth <= 0.09f) playerHealth = 100f;

        // Increase game score over time
        gameScore += (int) (Time.deltaTime + 1);
        if (gameScoreText)
        {
            gameScoreText.text = gameScore.ToString();
        }

        // Decrease player time limit (Player Phase)
        currentPlayerTL -= Time.deltaTime;
        if (playerTimerText)
        {
            playerTimerText.text = currentPlayerTL.ToString("F1");
        }
    }

    // Used to literally set the playing field.
    void SetupPlayingField()
    {
        // Missing UI reference
        if (!gameStateText || !playerTimerText || !gameStateText || !gameOverScreen)
        {
            Debug.Log("Missing UI reference component(s)");
        }
        
        // Initialize UI text, if applicable
        ChangeGameStateText(state);
        if (playerTimerText) playerTimerText.text = currentPlayerTL.ToString("F1");
        if (gameScoreText) gameScoreText.text = gameScore.ToString();

        // Setting player time limit
        currentPlayerTL = playerTimeLimit;

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
        currentPlayerTL = playerTimeLimit;
    }

    // Changing UI text based on game state
    void ChangeGameStateText(GamePhase state)
    {
        // Checks if UI is attached then change UI text, if true
        if (gameStateText)
        {
            if (state == GamePhase.PLAYERTURN) gameStateText.text = "Player Turn Phase";
            else if (state == GamePhase.BOATPHASE) gameStateText.text = "Sailboat Phase";
            else if (state == GamePhase.END) gameStateText.text = "Game Over";
        }
    }

    IEnumerator DisablePlayerUI()
    {
        transition.SetTrigger(Transition);
        yield return new WaitForSeconds(1f);
        playerUI.SetActive(false);
    }
}
