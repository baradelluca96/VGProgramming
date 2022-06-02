using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    GameObject target;
    float channelStatus = 0f;
    bool enableAction = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ENABLED ACTION? " + enableAction);
        if(enableAction && Input.GetButton("Action")) {
            target.GetComponent<PlayerAction>().Channel(channelStatus);
            channelStatus += Time.deltaTime + 0.5f;
            Debug.Log("CHANNELING ON " + target.name);
            if(channelStatus >= 100f)
            {
                target.GetComponent<PlayerAction>().ChannelComplete();
                enableAction = false;
            }else{
                DisableAction();
            }
        }else{
            if(channelStatus > 0f){
                DisableAction();
            }
        }
    }

    public void EnableAction(GameObject colliderObject) {
        Debug.Log("ENABLING ACTION WITH " + colliderObject.name);
        target = colliderObject;
        enableAction = true;
    }
    public void DisableAction() {
        target.GetComponent<PlayerAction>().ChannelInterrupt();
        channelStatus = 0f;
        enableAction = false;
    }
}
