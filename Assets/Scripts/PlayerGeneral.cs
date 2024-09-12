using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerGeneral : MonoBehaviour
{

    public PlayerController playerController;
    public GameObject umbrella;
    public UIManager ui;
    public LevelManager levelManager;
    Rigidbody2D playerBody;

    public int playerHealthMax;
    [HideInInspector]public int playerHealth;
    public float runSpeed = 40f;
    public int umbrellaGravityDecrease;

    float horizontalMove = 0f;
    bool jump = false;
    bool canJump = true;
    bool crouch = false;

    [HideInInspector] public int badLuckScore;
    public int badLuckLimit;


    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerHealth = playerHealthMax;
        badLuckScore = 0;
    }

    public void PlayerHit(int damage)
    {
        playerHealth -= damage;
        ui.UpdateHealthText();
        if (playerHealth <= 0)
        {
            PlayerDies();
        }
    }

    public void PlayerDies()
    {
        badLuckScore = 0;
        levelManager.LoadScene("GameOver");
    }


    void Update()
    {
        //Player Loses
        if (badLuckScore >= badLuckLimit)
        {
            PlayerDies();
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //Player Jumps
        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            jump = true;
        }

        //Player crouches
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = true;
        }

        //Brings out the umbrella
        if (Input.GetButtonDown("Umbrella"))
        {
            umbrella.SetActive(true);
            playerBody.gravityScale /= umbrellaGravityDecrease;
            canJump = false;
            ui.UpdateScore(1);
        } else if (Input.GetButtonUp("Umbrella")) {
            umbrella.SetActive(false);
            playerBody.gravityScale *= umbrellaGravityDecrease;
            canJump = true;
        }

        //Pauses Game
        if (Input.GetButtonDown("Pause"))
        {
            levelManager.LoadScene("Pause");
        }
    }

    private void FixedUpdate()
    {
        //Moves Player
        playerController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
