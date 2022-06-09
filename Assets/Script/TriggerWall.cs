using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] GameObject wallSound;
    GameObject sphere;


    void OnTriggerEnter(Collider other) {
        wall.SetActive(true);

        StartCoroutine("DestroySphere");
    }

    IEnumerator DestroySphere() {
        yield return new WaitForSeconds(1f);
        wallSound.GetComponent<AudioSource>().Play();
        Destroy(sphere);
    }
}
