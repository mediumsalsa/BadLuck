using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            Destroy(collision.gameObject);
            Debug.Log("Hit by brick");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
