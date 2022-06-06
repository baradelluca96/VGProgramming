using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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

    public void Start() {
        bg.SetActive(false);
        
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
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    void OnTriggerExit(Collider other) {
        bar.SetActive(false);
        bg.SetActive(false);
        currentTime = 0f;
        StopCoroutine("StartOxygenBar");
    }

}
