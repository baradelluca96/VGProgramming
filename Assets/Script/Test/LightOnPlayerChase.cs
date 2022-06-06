using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnPlayerChase : MonoBehaviour
{
    [SerializeField] Light outerLight;
    [SerializeField] Light selfLight;
    FieldOfView fov;
    
    // Start is called before the first frame update
    void Start()
    {
        outerLight.enabled = false;
        selfLight.enabled = false;
        fov = GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fov.canSeePlayer)
        {
            outerLight.enabled = true;
            selfLight.enabled = true;
        }else{
            outerLight.enabled = false;
            selfLight.enabled = false;
        }
    }
}