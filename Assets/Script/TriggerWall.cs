using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    public GameObject wall;

    void OnTriggerEnter(Collider other) {
        wall.SetActive(true);
    }
}
