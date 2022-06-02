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
        if(enableAction && Input.GetButton("Action")) {
            target.GetComponent<PlayerAction>().Channel(channelStatus);
            channelStatus += Time.deltaTime + 0.5f;
            if(channelStatus >= 100f)
            {
                target.GetComponent<PlayerAction>().ChannelComplete();
                enableAction = false;
            }else{
                DisableAction();
            }
        }
    }

    public void EnableAction(Collider collider) {
        target = collider.gameObject;
        enableAction = true;
    }
    public void DisableAction() {
        target.GetComponent<PlayerAction>().ChannelInterrupt();
        enableAction = false;
    }
}
