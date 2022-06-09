using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float baseSpeed = 12f;
    public float gravity = -100f; // Fixed gravity -9.81f;
    public float jumpHeight = 5f;

    public float modelRotationSpeedThirdPerson = 1000f;
    float x;
    float z;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    private Vector3 moveDirection;

    bool isGrounded;
    bool disabled;

    public bool invertMovement;

    private Animator anim;
    
    private GameObject playerModel;

    private void Start()
    {
      controller = GetComponent<CharacterController>();
      anim = GetComponentInChildren<Animator>();
      playerModel = GameObject.Find("Ellen");
    }
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

        if (!invertMovement){
          x = Input.GetAxis("Horizontal");
          z = Input.GetAxis("Vertical");
        }else{
          x = Input.GetAxis("Horizontal");
          z = Input.GetAxis("Vertical") * -1;
        }

        bool pressed = Input.GetKey("left shift");
        float currentSpeed = baseSpeed;
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime; // Current speed with acceleration, framerate independent;

        controller.Move(velocity * Time.deltaTime); // Real movement, should be framerate independent too, not connected to previous delta fix;

        if (invertMovement && move != Vector3.zero)
        {
          Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);

          playerModel.transform.rotation = Quaternion.RotateTowards(playerModel.transform.rotation, toRotation, modelRotationSpeedThirdPerson * Time.deltaTime);
        }
     
        /* if (pressed)
          {
            currentSpeed = currentSpeed * 2;
          }
        */
        if(move != Vector3.zero && !pressed)
        {
          Walk();
        }
        else if(move != Vector3.zero && pressed)
        {
          Run();
        }
        else if(move == Vector3.zero)
        {
          Idle();
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
          {
            Jump();
          }  
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

    private void Idle()
    {
      anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
      anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
      float currentSpeed = baseSpeed;
      currentSpeed = currentSpeed * 2;
      anim.SetFloat("Speed", 0.98f, 0.1f, Time.deltaTime);
    }

    private void Jump(){
      velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
      anim.SetTrigger("Jump");
    }
}
