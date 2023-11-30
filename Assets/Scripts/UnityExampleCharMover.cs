using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Originally from Unity examples at:
// https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
//
// 3:55 PM 10/3/2020
//
// Reworked by @kurtdekker so that it jumps reliably in modern Unity versions.
//
// To use:
//    - make your player shape about 1x2x1 in size
//    - put this script on the root of it
//
// That's it.

public class UnityExampleCharMover : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody rb;
    private float groundedTimer;        // to allow jumping when going down ramps
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = 9.81f;
    public InputActionProperty jumpButton;

    private void Start()
    {
        // always add a controller
        //controller = gameObject.AddComponent<CharacterController>();
    }
 
    void Update()
    {
        bool groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            // cooldown interval to allow reliable jumping even whem coming down ramps
            groundedTimer = 0.2f;
        }
        if (groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime;
        }
 
        // slam into the ground
 

        // apply gravity always, to let us track down ramps properly
        rb.velocity = new Vector3(0, rb.velocity.y - gravityValue * Time.deltaTime, 0);
        if (rb.velocity.y < 0)
        {
            // hit ground
            rb.velocity = Vector3.zero;
        }

        // gather lateral input control
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = Vector3.zero;
 
        // scale by speed
       // move *= playerSpeed;
 
        // only align to motion if we are providing enough input
       // if (move.magnitude > 0.05f)
       // {
          //  gameObject.transform.forward = move;
       // }
        float triggerValue = jumpButton.action.ReadValue<float>();
        // allow jump as long as the player is on the ground
        if (Input.GetButtonDown("Jump") || triggerValue != 0)
        {
            // must have been grounded recently to allow jump
            if (groundedTimer > 0)
            {
                // no more until we recontact ground
                groundedTimer = 0;

                // Physics dynamics formula for calculating jump up velocity based on height and gravity
                move.y = Mathf.Sqrt(jumpHeight * 2 * gravityValue);
                rb.velocity = move;

            }
        }
 
        // inject Y velocity before we use it

        // call .Move() once only
    
    }
}