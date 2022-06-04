using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class TeleportSound : MonoBehaviour
{
    [SerializeField] AudioClip[] teleportClips;
    [SerializeField] AudioClip discharge;
    AudioSource audioSource;
    bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        isPlaying = false;
    }

    // Update is called once per frame

    public void TriggerTeleport()
    {
        if(!isPlaying){
            Debug.Log("Playing Main Sound");
            int index = Random.Range(0, teleportClips.Length);
            audioSource.clip = teleportClips[index];
            audioSource.Play();
            isPlaying = true;
        }
    }

    public void InterruptTeleport()
    {
        if(isPlaying)
        {
            Debug.Log("Playing Discharge");
            audioSource.Stop();
            audioSource.clip = discharge;
            audioSource.Play();
            isPlaying = false;
        }
    }
}
