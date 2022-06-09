using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectPickUp : PlayerAction
{
    [SerializeField] float channelStepValue = 1.6f;

    public override void Channel(float value) {

    }

    public override void ChannelInterrupt(){

    }

    public override void ChannelComplete(){
        gameObject.tag = "Untagged";
        PlayerPrefs.SetInt( SceneManager.GetActiveScene().name, 1); // Complete the village
        SwitchScene();
        // Remove action from this object, change the tag so that is no more targetable;
    }

    public override float ChannelStep(){
        return channelStepValue;
    }

    private void SwitchScene(){
        bool runComplete = PlayerPrefs.GetInt("Run") > 0;
        bool villageComplete = PlayerPrefs.GetInt("Village") > 0;
        bool pyramidComplete = PlayerPrefs.GetInt("Pyramid") > 0;

        string scene = "Temple";
        
        if(runComplete && villageComplete && pyramidComplete)
        {
            scene = "Ending";
        }else if (runComplete || villageComplete || pyramidComplete)
        {
            scene = "TempleMidGame";
        }

        SceneManager.LoadScene(scene);
    }
}
