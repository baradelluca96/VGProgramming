using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTriggerIN : MonoBehaviour
{
    public GameObject firstPersonCam;
    public GameObject isometricCam;
    public GameObject player;
    public GameObject triggerOut;
    
    void OnTriggerEnter(Collider other) {
        triggerOut.SetActive(true);
    }
}
