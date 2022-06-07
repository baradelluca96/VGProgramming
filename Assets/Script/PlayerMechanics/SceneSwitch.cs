using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int IDScene;
    // public bool isFinish = false; 

    /*void onTriggerEnter(Collider other){
        if(isFinish){
            
        }
    }*/

    void finishLoad(){
        SceneManager.LoadScene(IDScene);
    }
}
