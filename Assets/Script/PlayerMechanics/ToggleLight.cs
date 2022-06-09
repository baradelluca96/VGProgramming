using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    Light spotlight;
    GameObject companion;
    TriggerUI ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("InGameUI").GetComponent<TriggerUI>();
        companion = GameObject.Find("Companion");
        Light spotlight = GetComponent<Light>();
        spotlight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Light spotlight = GetComponent<Light>();
        if(Input.GetButtonDown("ToggleUI"))
        {
            spotlight.enabled = !spotlight.enabled;
            companion.GetComponent<FollowPlayer>().uiTriggered = !companion.GetComponent<FollowPlayer>().uiTriggered;
        }

        if(spotlight.enabled)
        {
            ui.StepMoveCompanionOnUI();
        }
    }
}
