using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    Light spotlight;
    // Start is called before the first frame update
    void Start()
    {
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
        }
    }
}
