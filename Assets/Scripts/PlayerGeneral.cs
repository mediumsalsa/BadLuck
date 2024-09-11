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

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool canJump = true;
    bool crouch = false;


    [HideInInspector] public int badLuckScore;
    public int badLuckLimit;


    private void Start()
    {
      badLuckScore = 0;
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = true;
        }

        if (Input.GetButtonDown("Umbrella"))
        {
            umbrella.SetActive(true);
            canJump = false;
            ui.UpdateScore(1);
        } else if (Input.GetButtonUp("Umbrella")) {
            umbrella.SetActive(false);
            canJump = true;
        }

        if (Input.GetButtonDown("Pause"))
        {
            levelManager.LoadScene("Pause");
        }
    }

    private void LateUpdate()
    {
        if (badLuckScore >= badLuckLimit)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void FixedUpdate()
    {
        playerController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
