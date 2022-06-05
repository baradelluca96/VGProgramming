using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject Player;
    void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject == Player)
        {
            transform.parent = Player.transform ;
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
