using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanternAction : PlayerAction
{
    public string SceneName;
    public Light orbLight;
    [SerializeField] float channelStepValue = 0.4f;

    public override void Channel(float value) {
        orbLight.intensity += 0.02f;
        GetComponent<TeleportSound>().TriggerTeleport();
    }

    public override void ChannelInterrupt(){
        GetComponent<TeleportSound>().InterruptTeleport();
        orbLight.intensity = 1f;
    }

    public override void ChannelComplete(){
        gameObject.tag = "Untagged";
        SwitchScene();
        // Remove action from this object, change the tag so that is no more targetable;
    }

    public override float ChannelStep(){
        return channelStepValue;
    }

    private void SwitchScene(){
        SceneManager.LoadScene(SceneName);
    }
}
