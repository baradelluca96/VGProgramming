using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastAction : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    ActionController player;
    GameObject target;
    
    TriggerUI triggerUI;

    bool blockAction = false;
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
                if (hit.collider.gameObject != target){
                    Debug.Log("HIT another " + hit.collider.gameObject.name);
                    target = hit.collider.gameObject;
                    triggerUI.activateAction();
                    player.EnableAction(target);
                } // else keep going
            
            }else{
                blockAction = true;
            }
        }else{
            blockAction = true;
        }

        if(blockAction && target){
            triggerUI.disableAction();
            player.DisableAction();
            target = null;
            blockAction = false;
        }
    }
}
