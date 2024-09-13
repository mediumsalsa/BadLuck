using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{

    private PlayerGeneral player;
    public LevelManager levelManager;
    public AudioManager audio;

    private void Start()
    {
        player = FindObjectOfType<PlayerGeneral>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RabbitFoot")
        {
            audio.PlaySFX(audio.winSound);
            levelManager.LoadScene("GameWin");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            Destroy(collision.gameObject);
            player.PlayerHit(1);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            player.badLuckScore += 3;
            player.PlayerHit(1);
        }
        if (collision.gameObject.tag == "InstantDeath")
        {
            player.PlayerHit(1000);
        }
    }

}
