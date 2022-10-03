using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreGUI;
    
    public void SetUp(int score)
    {
        gameObject.SetActive(true);
        scoreGUI.text = $"Score: {score}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("WindZones");
    }
    
    public void MainMenu()
    {
        // TODO: Load main menu
        Debug.Log("TODO: Load Main Menu");
    }
}
