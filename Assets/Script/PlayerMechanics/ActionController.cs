using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    GameObject target;
    float channelStatus = 0f;
    bool enableAction = false;
    bool buttonDropped = false;
    [SerializeField] GameObject fillInteraction;
    Image fillImage;
    // Start is called before the first frame update
    void Start()
    {
        fillImage = fillInteraction.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enableAction && Input.GetButton("Action")) {
            target.GetComponent<PlayerAction>().Channel(channelStatus);
            channelStatus += Time.deltaTime + 0.5f;
            fillImage.fillAmount = channelStatus / 100f;
            if(channelStatus >= 100f)
            {
                target.GetComponent<PlayerAction>().ChannelComplete();
                enableAction = false;
            }
        }else{
            if(channelStatus > 0f){
                if(enableAction){
                    buttonDropped = true;
                }
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
        fillImage.fillAmount = 0f;

        if(!buttonDropped)
        {
            enableAction = false;
        }
    }
}
