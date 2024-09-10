using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public PlayerController playerController;
    public GameObject umbrella;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
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

        } else if (Input.GetButtonUp("Umbrella")) {

            umbrella.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        playerController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
