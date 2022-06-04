using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternAction : PlayerAction
{
    public Light orbLight;

    public override void Channel(float value) {
        orbLight.intensity += 0.02f;
        GetComponent<TeleportSound>().TriggerTeleport();
    }

    public override void ChannelInterrupt(){
        GetComponent<TeleportSound>().InterruptTeleport();
    }

    public override void ChannelComplete(){
        Debug.Log("COMPLETED!");
        gameObject.tag = "Untagged";
        // Remove action from this object, change the tag so that is no more targetable;
    }
}
