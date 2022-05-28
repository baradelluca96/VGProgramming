using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPrinter : MonoBehaviour
{
    TriggerUI uiHandler;
    // Start is called before the first frame update
    void Start()
    {
        uiHandler = GetComponent<TriggerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrintMovementInstructions()
    {
        uiHandler.showUI("movement");
    }

    public void RemoveMovementInstructions()
    {
        Debug.Log("REMOVE MOV INSTRUCTIONS");
        uiHandler.unlockUI();
    }

    public void ShowOrbInstructions()
    {
        Debug.Log("START SHOW ORB");
        uiHandler.showUI("orbInstructions");
    }

    public void RemoveOrbInstructions()
    {
        uiHandler.unlockUI();
    }
}
