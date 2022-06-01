using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class BarOssygen : MonoBehaviour
{
    public GameObject bar;
    public int time;
    public GameObject progressText;
    

    void Start()
    {
        AnimateBar();
    }


    public void AnimateBar() {
        LeanTween.scaleX(bar, 0, time).setOnUpdate(setProgressText).setOnUpdateParam(progressText);
        
        
    }

    public void setProgressText(float val, object obj) {
        obj = val * 100f + "%";
    } 

}
