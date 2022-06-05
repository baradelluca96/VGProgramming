using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public GameObject firstPersonCam;
    public GameObject isometricCam;
    public GameObject playerMovementChange;
    public GameObject triggerIn;
    
    void OnTriggerEnter(Collider other) {
        isometricCam.SetActive(false);
        firstPersonCam.SetActive(true);
        triggerIn.SetActive(false);
        playerMovementChange.GetComponent<PlayerMovement>().invertMovement = false;
    }

    void OnTriggerExit(Collider other) {
        firstPersonCam.SetActive(false);
        isometricCam.SetActive(true);
        playerMovementChange.GetComponent<PlayerMovement>().invertMovement = true;
    }

}
