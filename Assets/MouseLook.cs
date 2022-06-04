using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(50f, 200f)]
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float lockAngle = 60f;
    float xRotation = 0f;

    public Light companionSpotlight;
    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // This should rotate the player too
      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

      xRotation -= mouseY;
      xRotation = Mathf.Clamp(xRotation, -lockAngle, lockAngle);
     
      playerBody.Rotate(Vector3.up * mouseX);
      companionSpotlight.transform.rotation = Quaternion.Slerp(companionSpotlight.transform.rotation, transform.rotation, 0.5f);
      transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
