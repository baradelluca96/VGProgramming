using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstructions : MonoBehaviour
{
    [SerializeField] bool showMovementInstructions;
    [SerializeField] bool showOrbInstructions;
    [SerializeField] bool showTorchLightInstructions;
    [SerializeField] float showMovementInstructionsAfter = 2.5f;
    bool hasMoved = false;
    InstructionPrinter printer;
    // Start is called before the first frame update
    void Start()
    {
        printer = GameObject.Find("InGameUI").GetComponent<InstructionPrinter>();
        if(showMovementInstructions)
        {
            StartCoroutine("ShowMovementInstructions");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasMoved && showMovementInstructions && (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")))
        {
            hasMoved = true;
            showMovementInstructions = false;
            printer.RemoveMovementInstructions();
        }
    }

    IEnumerator ShowMovementInstructions() {
        yield return new WaitForSeconds(showMovementInstructionsAfter);
        if(!hasMoved)
        {
            printer.PrintMovementInstructions();
        }
    }

    IEnumerator RemoveInstrucitons() {
        yield return new WaitForSeconds(8f);
        printer.RemoveInstructions();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "OrbInstructionTrigger" && showOrbInstructions)
        {
            showOrbInstructions = false;
            printer.ShowOrbInstructions();
            StartCoroutine("RemoveInstrucitons");
        }

        if(other.gameObject.name == "TorchInstructionTrigger" && showTorchLightInstructions)
        {
            showTorchLightInstructions = false;
            printer.ShowTorchInstructions();
            StartCoroutine("RemoveInstrucitons");
        }
    }
}
