using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Channel(float value) {
        Debug.Log("CHANNELING AT" + value);
    }

    public void ChannelInterrupt(){
        Debug.Log("INTERRUPT");
    }

    public void ChannelComplete(){
        Debug.Log("COMPLETED!");
    }
}
