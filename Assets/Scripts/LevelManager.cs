using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject _player;
    public PlayerGeneral playerGeneral;
    public UIManager ui;

    public void LoadScene(string levelName)
    {
        //Resets the badLuckScore every time a scene loads
        playerGeneral.badLuckScore = 0;
        ui.UpdateScore(0);
        playerGeneral.playerHealth = playerGeneral.playerHealthMax;
        ui.UpdateHealthText();

        SceneManager.sceneLoaded += OnSceneLoaded;

        string currentScene = SceneManager.GetActiveScene().name;

        if (levelName != null)
        {
            //Loads the Main Menu
            if (levelName.StartsWith("MainMenu"))
            {
                SceneManager.LoadScene(levelName);
                gameManager.gameState = GameManager.GameState.MainMenu;
            }
            //Loads Level 1
            else if (levelName.StartsWith("Level_1"))
            {
                SceneManager.LoadScene(levelName);
                gameManager.gameState = GameManager.GameState.Gameplay;
            }
            //Loads level 2
            else if (levelName.StartsWith("Level_2"))
            {
                SceneManager.LoadScene(levelName);
                gameManager.gameState = GameManager.GameState.Gameplay;
            }
            //Player wins
            else if (levelName.StartsWith("GameWin"))
            {
                SceneManager.LoadScene(levelName);
                gameManager.gameState = GameManager.GameState.GameWin;
            }
            //Player Loses
            else if (levelName.StartsWith("GameOver"))
            {
                gameManager.gameState = GameManager.GameState.GameOver;
            }
            //Pause game
            else if (levelName.StartsWith("Pause"))
            {
                gameManager.gameState = GameManager.GameState.Paused;
                Time.timeScale = 0;
            }
            //Resume
            else if (levelName.StartsWith("Resume"))
            {
                Time.timeScale = 1;
                //resumes back to gameplay
                if (currentScene.StartsWith("Level"))
                {
                    gameManager.gameState = GameManager.GameState.Gameplay;
                }
                //Resumes back to Main Menu
                else if (currentScene.StartsWith("MainMenu"))
                {
                    gameManager.gameState = GameManager.GameState.MainMenu;
                }
            }
            //Shows options
            else if (levelName.StartsWith("Options"))
            {
                gameManager.gameState = GameManager.GameState.Options;
            }
        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameManager.PlayerSpawn();
    }
}
