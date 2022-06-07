using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarOssygen : MonoBehaviour
{
    public GameObject bg;
    public GameObject bar;
    private Image slideBar;
    public float time;
    private float currentTime;
    public GameObject timeUpMessage;
    public GameObject collider;

    private int scaleID;

    private Scene scene;

    public void Start() {
        bg.SetActive(false);
        // Scena attuale
        scene = SceneManager.GetActiveScene();
    }

    void OnTriggerEnter(Collider other) {
        bar.SetActive(true);
        bg.SetActive(true);     
        slideBar = bar.GetComponent<Image>();

        StartCoroutine("StartOxygenBar");
    }

    IEnumerator StartOxygenBar(){
        slideBar.fillAmount = 1;
        while( currentTime <= time ) {
            currentTime += 0.1f;
            slideBar.fillAmount -=  0.1f / time;
            if(slideBar.fillAmount < 0.09f){
                Debug.Log("Eccoci: "+ slideBar.fillAmount);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update(){
        if(slideBar.fillAmount == 0.01f){
            Debug.Log("Eccoci");
            Application.LoadLevel(scene.name);
        }
    }
    
    void OnTriggerExit(Collider other) {
        bar.SetActive(false);
        bg.SetActive(false);
        currentTime = 0f;
        StopCoroutine("StartOxygenBar");
    }

}
