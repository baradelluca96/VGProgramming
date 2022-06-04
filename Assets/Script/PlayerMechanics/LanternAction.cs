using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternAction : PlayerAction
{
    public Light orbLight;
    [SerializeField] float channelStepValue = 0.4f;

    public override void Channel(float value) {
        orbLight.intensity += 0.02f;
        GetComponent<TeleportSound>().TriggerTeleport();
    }

    public override void ChannelInterrupt(){
        Debug.Log("CHANNEL INTERRUPT");
        GetComponent<TeleportSound>().InterruptTeleport();
    }

    public override void ChannelComplete(){
        Debug.Log("COMPLETED!");
        gameObject.tag = "Untagged";
        // Remove action from this object, change the tag so that is no more targetable;
    }

    public override float ChannelStep(){
        return channelStepValue;
    }
}
