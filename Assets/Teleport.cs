using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    GameObject gameObj;
    [SerializeField] Transform destination; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other) {
        gameObj = other.gameObject;
        Debug.Log("Sto entrando"+other.gameObject.name);
        StartCoroutine("TeleportRoutine");
    }

    IEnumerator TeleportRoutine() {
        Debug.Log("Sto entrando??");
        PlayerMovement script = gameObj.GetComponent<PlayerMovement>();
        script.Disable();
        gameObj.transform.position = destination.position;
        gameObj.transform.rotation = destination.rotation;
        
        yield return null;
        script.Enable();
    }
}
