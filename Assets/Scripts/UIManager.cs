using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public PlayerGeneral player;

    [SerializeField] TextMeshProUGUI scoreText;

    public GameObject oMainMenu;
    public GameObject oGameplay;
    public GameObject oPaused;
    public GameObject oOptions;
    public GameObject oGameOver;
    public GameObject oGameWin;

    private void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int points)
    {
        player.badLuckScore += points;
        scoreText.text = "Bad Luck Meter: " + player.badLuckScore;
    }

    public void UI_MainMenu()
    {
        SetAllFalse();
        oMainMenu.SetActive(true);
    }
    public void UI_Gameplay()
    {
        SetAllFalse();
        oGameplay.SetActive(true);
    }
    public void UI_Paused()
    {
        SetAllFalse();
        oPaused.SetActive(true);
    }
    public void UI_Options()
    {
        SetAllFalse();
        oOptions.SetActive(true);
    }
    public void UI_GameOver()
    {
        SetAllFalse();
        oGameOver.SetActive(true);
    }
    public void UI_GameWin()
    {
        SetAllFalse();
        oGameWin.SetActive(true);
    }
    public void SetAllFalse()
    {
        oMainMenu.SetActive(false);
        oGameplay.SetActive(false);
        oPaused.SetActive(false);
        oOptions.SetActive(false);
        oGameOver.SetActive(false);
        oGameWin.SetActive(false);
    }

}
