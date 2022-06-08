using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerOnAxis : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    [SerializeField] float initialZ = -175f;
    [SerializeField] float playerTargetTriggerZ = -90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRef.transform.position.z <= -playerTargetTriggerZ)
        {
           transform.position =  new Vector3(transform.position.x, transform.position.y,(initialZ + playerRef.transform.position.z + playerTargetTriggerZ));
        }
    }
}
