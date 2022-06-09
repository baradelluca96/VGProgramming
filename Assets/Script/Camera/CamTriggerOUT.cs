using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTriggerOUT : MonoBehaviour
{
    public GameObject firstPersonCam;
    public GameObject isometricCam;
    public GameObject playerMovementChange;
    public GameObject triggerOut;
    
    void OnTriggerEnter(Collider other) {
        isometricCam.GetComponent<Camera>().enabled = false;
        firstPersonCam.GetComponent<Camera>().enabled = true;
        triggerOut.SetActive(true);
        playerMovementChange.GetComponent<PlayerMovement>().invertMovement = false;
    }

    void OnTriggerExit(Collider other) {
        isometricCam.GetComponent<Camera>().enabled = true;
        firstPersonCam.GetComponent<Camera>().enabled = false;
        triggerOut.SetActive(false);
        playerMovementChange.GetComponent<PlayerMovement>().invertMovement = true;
    }

}
