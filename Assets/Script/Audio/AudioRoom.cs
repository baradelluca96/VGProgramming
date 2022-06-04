using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRoom : MonoBehaviour

{

  public GameObject ambientObject;
  bool transitionEnter = true;
  bool transitionExit = false;
  public float minVolume = 0.2f;
  public float maxVolume = 0.6f;
  public float paramChangeRate = 0.5f;
  public float minFilterHz = 5000f;
  public float maxFilterHz = 20000f;
  // Start is called before the first frame update
  void Start()
    {
    AudioLowPassFilter filter = ambientObject.GetComponent<AudioLowPassFilter>();
    AudioSource source = ambientObject.GetComponent<AudioSource>();
    if (transitionEnter)
    {
      filter.cutoffFrequency = minFilterHz;
      source.volume = minVolume;
    }
    else
    {
      filter.cutoffFrequency = maxFilterHz;
      source.volume = maxVolume;
    }
  }

    // Update is called once per frame
    void Update()
    {
      AudioLowPassFilter filter = ambientObject.GetComponent<AudioLowPassFilter>();
      AudioSource source = ambientObject.GetComponent<AudioSource>();

      float volumeStep = (maxVolume - minVolume) * paramChangeRate;
      float cutoffStep = (maxFilterHz - minFilterHz) * paramChangeRate;

      if (transitionEnter)
      {
        if(filter.cutoffFrequency > minFilterHz)
        {
          filter.cutoffFrequency -= cutoffStep * Time.deltaTime;
        }

        if(source.volume > minVolume)
        {
          source.volume -= volumeStep * Time.deltaTime;
        }
      }

      if(transitionExit)
      {
        if (filter.cutoffFrequency < maxFilterHz)
        {
          filter.cutoffFrequency += cutoffStep * Time.deltaTime;
        }

        if (source.volume < maxVolume)
        {
          source.volume += volumeStep * Time.deltaTime;
        }
      }
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag == "InnerTempleVol")
      {
        transitionEnter = true;
        transitionExit = false;
      }
    }

    void OnTriggerExit(Collider other)
    {
      if (other.gameObject.tag == "InnerTempleVol")
      {
        transitionEnter = false;
        transitionExit = true;
      }
    }
}
