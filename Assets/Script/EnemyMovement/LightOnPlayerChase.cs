using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnPlayerChase : MonoBehaviour
{
    [SerializeField] Light outerLight;
    [SerializeField] Light selfLight;
    FieldOfView fov;
    AudioSource angrySound;
    bool audioPlaying;
    
    // Start is called before the first frame update
    void Start()
    {
        audioPlaying = false;
        angrySound = GetComponent<AudioSource>();
        outerLight.enabled = false;
        selfLight.enabled = false;
        fov = GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fov.canSeePlayer)
        {
            if(!audioPlaying)
            {
                Debug.Log("playAngry");
                audioPlaying = true;
                angrySound.Play();
            }
            outerLight.enabled = true;
            selfLight.enabled = true;
        }else{
            angrySound.Stop();
            audioPlaying = false;
            outerLight.enabled = false;
            selfLight.enabled = false;
        }
    }
}