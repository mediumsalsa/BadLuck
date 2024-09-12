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
        //kills player
        if (collision.gameObject.tag == "Brick")
        {
            Destroy(collision.gameObject);
            player.PlayerHit(1);
        }
    }

}
