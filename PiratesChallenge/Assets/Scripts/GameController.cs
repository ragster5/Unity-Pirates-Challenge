using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    // Start is called before the first frame update
    void Start()
    {
        gamePhase = GamePhases.Game;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
