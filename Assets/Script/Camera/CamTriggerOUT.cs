using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTriggerOUT : MonoBehaviour
{
    [SerializeField] GameObject firstPersonCam;
    [SerializeField] GameObject isometricCam;
    [SerializeField] GameObject player;
    [SerializeField] GameObject triggerOut;
    [SerializeField] bool reversePlayer;
    
    void OnTriggerEnter(Collider other) {
        isometricCam.GetComponent<Camera>().enabled = false;
        firstPersonCam.GetComponent<Camera>().enabled = true;
        firstPersonCam.GetComponent<MouseLook>().enabled = true;
        triggerOut.SetActive(true);
        player.GetComponent<PlayerMovement>().invertMovement = false;
        if(reversePlayer)
        {
            player.transform.forward = Vector3.forward * -1;
        }
    }

    void OnTriggerExit(Collider other) {
        isometricCam.GetComponent<Camera>().enabled = true;
        firstPersonCam.GetComponent<Camera>().enabled = false;
        firstPersonCam.GetComponent<MouseLook>().enabled = false;
        triggerOut.SetActive(false);
        player.GetComponent<PlayerMovement>().invertMovement = true;
        player.transform.forward = Vector3.forward;
    }

}
