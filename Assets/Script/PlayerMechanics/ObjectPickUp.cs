using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectPickUp : PlayerAction
{
    public int IDScene;
    [SerializeField] float channelStepValue = 1.6f;

    public override void Channel(float value) {

    }

    public override void ChannelInterrupt(){

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
        SceneManager.LoadScene(IDScene);
    }
}
