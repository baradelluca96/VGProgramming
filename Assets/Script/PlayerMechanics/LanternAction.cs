using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternAction : PlayerAction
{
    public Light orbLight;

    public override void Channel(float value) {
        orbLight.intensity += 0.02f;
    }

    public override void ChannelInterrupt(){
        Debug.Log("INTERRUPT");
    }

    public override void ChannelComplete(){
        Debug.Log("COMPLETED!");
        gameObject.tag = "Untagged";
        // Remove action from this object, change the tag so that is no more targetable;
    }
}
