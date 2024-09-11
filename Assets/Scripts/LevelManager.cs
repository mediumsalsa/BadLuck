using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject _player;

    public void LoadScene(string levelName)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        string currentScene = SceneManager.GetActiveScene().name;

        if (levelName != null)
        {
            if (levelName.StartsWith("MainMenu"))
            {
                SceneManager.LoadScene(levelName);
                gameManager.gameState = GameManager.GameState.MainMenu;
            }
            else if (levelName.StartsWith("Level_1"))
            {
                SceneManager.LoadScene(levelName);
                gameManager.gameState = GameManager.GameState.Gameplay;
            }
            else if (levelName.StartsWith("Level_1"))
            {
                SceneManager.LoadScene(levelName);
                gameManager.gameState = GameManager.GameState.Gameplay;
            }
            else if (levelName.StartsWith("GameWin"))
            {
                SceneManager.LoadScene(levelName);
                gameManager.gameState = GameManager.GameState.GameWin;
            }
            else if (levelName.StartsWith("Pause"))
            {
                gameManager.gameState = GameManager.GameState.Paused;
            }
            else if (levelName.StartsWith("Resume"))
            {
                if (currentScene.StartsWith("Level"))
                {
                    gameManager.gameState = GameManager.GameState.Gameplay;
                }
                else if (currentScene.StartsWith("MainMenu"))
                {
                    gameManager.gameState = GameManager.GameState.MainMenu;
                }
            }
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
