using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public GameObject firstPersonCam;
    public GameObject isometricCam;
    
    void OnTriggerEnter(Collider other) {
        isometricCam.SetActive(false);
        firstPersonCam.SetActive(true);
    }

    void OnTriggerExit(Collider other) {
        firstPersonCam.SetActive(false);
        isometricCam.SetActive(true);
    }

}
