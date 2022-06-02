using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class BarOssygen : MonoBehaviour
{
    public GameObject bar;
    public int time;
    public GameObject timeUpMessage;
    public GameObject collider;
    public bool activeBar = false;
   


    void Start()
    {
         if(activeBar == true){
            AnimateBar();
        }else{
            LeanTween.scaleX(bar, 1, time);
        }
    }
    void Update() {
        
    }
    
    public void AnimateBar() {
        LeanTween.scaleX(bar, 0, time)
        .setOnComplete(showMessage);    
       // .setOnUpdate(setProgressText(time));
    }

    void showMessage() {
        timeUpMessage.SetActive(true);
    }

    /* public void setProgressText(float val) {
        timeUpMessage.GetComponent<TextUI>().text = val * 100f + "%";
      //  timeUpMessage.text = val * 100f + "%";
    } 
    */

    void OnTriggerEnter(Collider other) {
        activeBar = true;
        bar.SetActive(true);
    }
    
    void OnTriggerExit(Collider other) {
        activeBar = true;
        bar.SetActive(false);
    }

}
