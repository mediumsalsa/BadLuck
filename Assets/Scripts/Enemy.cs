using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float mMovementSpeed = 3.0f;
    public float mRaycastingDistance = 1f;
    public bool bIsGoingRight = true;

    private SpriteRenderer _mSpriteRenderer;


    void Start()
    {
        _mSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _mSpriteRenderer.flipX = bIsGoingRight;
    }


    void Update()
    {
        //Enemy going right 
        Vector3 directionTranslation = (bIsGoingRight) ? transform.right : -transform.right;
        directionTranslation *= Time.deltaTime * mMovementSpeed;

        transform.Translate(directionTranslation);

        CheckForWalls();
    }

    private void CheckForWalls()
    {
        Vector3 raycastDirection = (bIsGoingRight) ? Vector3.right : Vector3.left;

        //Checks to see what is in front of the enemy
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastDirection * mRaycastingDistance - new Vector3(0f, 0.25f, 0f), raycastDirection, 0.075f);

        //does something based on whats in front of the enemy
        if (hit.collider != null)
        {
            if (hit.transform.tag == "Ground" || hit.transform.tag == "Enemy")
            {
                bIsGoingRight = !bIsGoingRight;
                _mSpriteRenderer.flipX = bIsGoingRight;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            Destroy(gameObject);
        }
    }


}
