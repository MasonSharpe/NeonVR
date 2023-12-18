using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandler : MonoBehaviour
{
    public CharacterController character;
    public float jumpHeight = 5;
    public float gravity = -9.81f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    public void Jump()
    {
        character.Move(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * gravity));
    }
}
