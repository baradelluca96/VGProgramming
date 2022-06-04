using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFollowSphere : MonoBehaviour
{
    public GameObject wallStopSphere;
  
    public GameObject Sphere;
    public GameObject rotationSphere;

    void Start() {
        Sphere.GetComponent<WaypointController>().enabled = false;
        rotationSphere.GetComponent<SphereRotation>().enabled = false;
    }

    void OnTriggerEnter(Collider other) {
        wallStopSphere.SetActive(false);
        Sphere.GetComponent<WaypointController>().enabled = true;
        rotationSphere.GetComponent<SphereRotation>().enabled = true;
    }
}
