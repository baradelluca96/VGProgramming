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
        Debug.Log(enableAction);
        Debug.Log(Input.GetButton("Action"));

        if(enableAction && Input.GetButton("Action")) {
            target.GetComponent<PlayerAction>().Channel(channelStatus);
            channelStatus += Time.deltaTime + target.GetComponent<PlayerAction>().ChannelStep();
            fillImage.fillAmount = channelStatus / 100f;
            if(channelStatus >= 100f)
            {
                target.GetComponent<PlayerAction>().ChannelComplete();
                enableAction = false;
            }
        }else if(enableAction && channelStatus > 0f){
            target.GetComponent<PlayerAction>().ChannelInterrupt();
            fillImage.fillAmount = 0f;
            channelStatus = 0f;
        }
    }

    public void EnableAction(GameObject colliderObject) {
        target = colliderObject;
        enableAction = true;
    }
    public void DisableAction() {
        channelStatus = 0f;
        fillImage.fillAmount = 0f;
        enableAction = false;
    }
}
