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
        isometricCam.SetActive(false);
        firstPersonCam.SetActive(true);
        triggerOut.SetActive(true);
        playerMovementChange.GetComponent<PlayerMovement>().invertMovement = false;
    }

    void OnTriggerExit(Collider other) {
        triggerOut.SetActive(false);
        firstPersonCam.SetActive(false);
        isometricCam.SetActive(true);
        playerMovementChange.GetComponent<PlayerMovement>().invertMovement = true;
    }

}
