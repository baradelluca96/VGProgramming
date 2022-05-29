using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float baseSpeed = 12f;
    public float gravity = -100f; // Fixed gravity -9.81f;
    public float jumpHeight = 5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool disabled;

    // Update is called once per frame
    void Update()
    {
      if(!disabled){
        // Checks if a small sphere around the GroundCheck object is colliding with something
        // in this case a mask (a subgroup of objects or layer)
        // Note: The player is not in this group, otherwis it will collide with himself and be always grunded;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y < 0)
          {
            velocity.y = -2f; // A constance force pushing on the ground;
          }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool pressed = Input.GetKey("left shift");
        float currentSpeed = baseSpeed;
        if (pressed)
          {
            currentSpeed = currentSpeed * 2;
          }

        if(Input.GetButtonDown("Jump") && isGrounded)
          {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
          }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime; // Current speed with acceleration, framerate independent;

        controller.Move(velocity * Time.deltaTime); // Real movement, should be framerate independent too, not connected to previous delta fix;
      }
    }

    public bool Disable() {
      disabled = true;
      return disabled;
    }

    public bool Enable() {
      disabled = false;
      return disabled;
    }
}
