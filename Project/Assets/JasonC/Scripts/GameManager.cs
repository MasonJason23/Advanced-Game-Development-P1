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
    // Singleton Approach
    public static GameManager GmInstance { get; private set; }

    // Reference to UI "screens"
    public GameOverScreen gameOverScreen;
    public GameObject playerUI;
    
    // Reference to Animator
    public Animator transition;
    private static readonly int Transition = Animator.StringToHash("Transition");
    
    // Game state
    public GamePhase state = GamePhase.START;
    public bool stopUpdating = false;

    // UI reference
    public TextMeshProUGUI gameScoreText; // required
    
    // Keep track of player's time limit and score
    public int gameScore = 0;
    public float playerTimeLimit = 10f;
    public float currentPlayerTL; 
    
    // Player Health
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

    private void Awake()
    {
        if (GmInstance == null)
        {
            GmInstance = this;
        }
        else
        {
            Destroy(this); // There already is a GameManager in the scene
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Instantiates game objects and UI, nothing implemented atm
        SetupPlayingField();
    }

    private void Update()
    {
        // Game has ended
        if (stopUpdating) return;
        
        // End the game when player health reaches zero
        if (state == GamePhase.BOATPHASE)
        {
            playerHealth -= Time.deltaTime;
            if (playerHealth <= 0.01f)
            {
                state = GamePhase.END;
            }
        }
        
        // Check time to make sure to change to next phase
        if (currentPlayerTL <= 0f)
        {
            StartNextPhase();
        }

        // Increase game score over time
        gameScore += (int) (Time.deltaTime + 1);
        if (gameScoreText)
        {
            gameScoreText.text = gameScore.ToString();
        }

        // Decrease player time limit (Player Phase)
        currentPlayerTL -= Time.deltaTime;

        // Ends the game
        if (state == GamePhase.END)
        {
            StartCoroutine(DisablePlayerUI());
            gameOverScreen.SetUp(gameScore);
            stopUpdating = true;
        }
    }

    // Used to literally set the playing field.
    void SetupPlayingField()
    {
        // Missing UI reference
        if (!gameScoreText || !gameOverScreen)
        {
            Debug.Log("Missing UI reference component(s)");
        }

        // Initialize UI text, if applicable
        if (gameScoreText) gameScoreText.text = gameScore.ToString();

        // Setting player time limit
        currentPlayerTL = playerTimeLimit;

        // After setting up game area, player is immediately given their "turn" to play.
        state = GamePhase.PLAYERTURN;
        
        // Invoke event
        changePhase?.Invoke(state);
    }
    
    // Function is also used by a UI button to start the BoatPhase
    public void StartNextPhase()
    {
        // Switch game state to other phase based on current game state
        if (state == GamePhase.PLAYERTURN)
            state = GamePhase.BOATPHASE;
        else if (state == GamePhase.BOATPHASE) state = GamePhase.PLAYERTURN;

        // Invoke event
        changePhase?.Invoke(state);

        // Reset player time
        currentPlayerTL = playerTimeLimit;
    }

    IEnumerator DisablePlayerUI()
    {
        transition.SetTrigger(Transition);
        yield return new WaitForSeconds(1f);
        playerUI.SetActive(false);
    }
}
