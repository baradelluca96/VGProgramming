using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelOnFallDown : MonoBehaviour
{

    [SerializeField] string strTag = "Player"; 
    private void OnCollisionEnter(Collision collision){
        
        if(collision.collider.tag == strTag){   // if tag collide obj
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log(collision.collider.tag);
            Debug.Log(strTag);
        } 
    }
}
