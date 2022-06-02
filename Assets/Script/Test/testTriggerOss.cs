using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTriggerOss : MonoBehaviour
{
    public GameObject bar;

    void OnTriggerEnter(Collider other) {
        bar.SetActive(true);
    }
    
    void OnTriggerExit(Collider other) {
        bar.SetActive(false);
    }
}
