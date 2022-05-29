using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelOnFallDown : MonoBehaviour
{
    private Scene scene;

    void Start() {
        // Scena attuale
        scene = SceneManager.GetActiveScene();
    }

    void OnTriggerEnter(Collider other){
        // Se tocca Player allora ricomincia livello
        if(other.gameObject.tag == "Player") {
            Application.LoadLevel(scene.name);
        }
    }
}
