using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{

    private PlayerGeneral player;

    private void Start()
    {
        player = FindObjectOfType<PlayerGeneral>();
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
            player.badLuckScore += 2;
            player.PlayerHit(1);
        }
        if (collision.gameObject.tag == "InstantDeath")
        {
            player.PlayerHit(1000);
        }
    }

}
