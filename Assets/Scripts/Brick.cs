using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{

    AudioManager audio;

    private void Start()
    {
        audio = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Umbrella")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy" )
        {
            audio.PlaySFX(audio.brickSound);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "InstantDeath")
        {
            Destroy(gameObject);
        }
    }
}
