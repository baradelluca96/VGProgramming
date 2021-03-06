using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarOxygen : MonoBehaviour
{
    public GameObject bg;
    public GameObject bar;
    private Image slideBar;
    public float time;
    private float currentTime;
    public GameObject timeUpMessage;

    private int scaleID;

    public void Start() {
        bg.SetActive(false);
        
    }

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.name == "OxygenRequired")
        {
            bar.SetActive(true);
            bg.SetActive(true);     
            slideBar = bar.GetComponent<Image>();
            RenderSettings.ambientIntensity = 0.1f;

            StartCoroutine("StartOxygenBar");
        }
    }

    IEnumerator StartOxygenBar(){
        slideBar.fillAmount = 1;
        while( currentTime <= time ) {
            currentTime += 0.1f;
            slideBar.fillAmount -=  0.1f / time;
            if(slideBar.fillAmount < 0.02f){
                Application.LoadLevel("Pyramid");
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    void OnTriggerExit(Collider other) {
        if(other.gameObject.name == "OxygenRequired")
        {
            bar.SetActive(false);
            bg.SetActive(false);
            currentTime = 0f;
            StopCoroutine("StartOxygenBar");
            RenderSettings.ambientIntensity = 1f;
        }
    }

}
