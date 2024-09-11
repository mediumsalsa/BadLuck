using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public PlayerGeneral player;

    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int points)
    {
        player.badLuckScore += points;
        scoreText.text = "Bad Luck Meter: " + player.badLuckScore;
    }

}
