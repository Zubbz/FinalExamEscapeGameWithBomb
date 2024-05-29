using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float charSpeed = 5f;
    public float charGravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    Vector3 charVelocity;
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //  Checks if the character is on the ground

        if(isGrounded && charVelocity.y <= 0)
        {
            charVelocity.y = 0f;
        }

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * xAxis + transform.forward * zAxis;

        controller.Move(movement * charSpeed * Time.deltaTime);


        charVelocity.y += charGravity * Time.deltaTime;

        controller.Move(charVelocity * Time.deltaTime);
    }
}
