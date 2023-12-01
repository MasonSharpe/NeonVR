using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class UnityExampleCharMover : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody rb;
    private float groundedTimer;    
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = 9.81f;
    public InputActionProperty jumpButton;


 
    void Update()
    {
        bool groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            groundedTimer = 0.2f;
        }
        if (groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime;
        }
 
 

        rb.velocity = new Vector3(0, rb.velocity.y - gravityValue * Time.deltaTime, 0);
        if (rb.velocity.y < 0)
        {
            rb.velocity = Vector3.zero;
        }


        Vector3 move = Vector3.zero;
 
 
        float triggerValue = jumpButton.action.ReadValue<float>();
        if (Input.GetButtonDown("Jump") || triggerValue != 0)
        {
            if (groundedTimer > 0)
            {
                groundedTimer = 0;

                move.y = Mathf.Sqrt(jumpHeight * 2 * gravityValue);
                rb.velocity = move;

            }
        }
        //controller.gameObject.transform.position = new Vector3(0, controller.gameObject.transform.position.y, 0);

    
    }
}