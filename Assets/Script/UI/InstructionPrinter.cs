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
        uiHandler.unlockUI();
    }

    public void ShowOrbInstructions(int index)
    {
        uiHandler.showUI("orbInstructions" + index);
    }

    public void RemoveInstructions()
    {
        uiHandler.unlockUI();
    }

    public void ShowTorchInstructions()
    {
        uiHandler.showUI("torchInstructions");
    }

    public void PrintInitialDialogue(int index)
    {
        uiHandler.showUI("dialogue" + index);
    }
}
