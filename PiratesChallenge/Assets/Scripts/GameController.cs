using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum GamePhases
{
    Introduction, Game, End, GameOver
}
public class GameController : MonoBehaviour
{
    public static GamePhases gamePhase;
    [Header("Database")]
    public GameObject gameOverPanel;
    public GameObject explosion, fire;
    public TextMeshProUGUI scoreTxt;

    int scoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        scoreNumber = 0;
        gamePhase = GamePhases.Game;
        scoreTxt.text = "Score: " + scoreNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int value)
    {
        scoreNumber += value;
        scoreTxt.text = "Score: " + scoreNumber;
        PlayerPrefs.SetInt("Score", scoreNumber);
    }
    public void TitleButton()
    {
        SceneManager.LoadScene("Title");
    }
    public void GameOverMenu()
    {
        gameOverPanel.SetActive(true);
    }
    public void Continue()
    {
        SceneManager.LoadScene("Game");
    }
    public void EndGame()
    {
        SceneManager.LoadScene("End");
    }
}
