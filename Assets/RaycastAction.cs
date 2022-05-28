using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAction : MonoBehaviour
{
    bool wasHit = false;
    [SerializeField] GameObject playerObject;
    ActionController player;
    
    TriggerUI triggerUI;
    // Start is called before the first frame update
    void Start()
    {
        triggerUI = GameObject.Find("InGameUI").GetComponent<TriggerUI>();
        player = playerObject.GetComponent<ActionController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10f);

        // TODO ASSOLUTAMENTE DA FARE REFACTOR
        if(Physics.Raycast(landingRay, out hit, 7f))
        {
            if(hit.collider.tag == "ObjectWithAction")
            {
                if(!wasHit){
                    wasHit = true;
                    triggerUI.activateAction();
                    player.EnableAction(hit.collider);
                }
            }else{
                if(wasHit){
                    wasHit = false;
                    triggerUI.disableAction();
                    player.DisableAction();
                }
            }
        }else{
            if(wasHit){
                wasHit = false;
                triggerUI.disableAction();
                player.DisableAction();
            }
        }
    }
}
