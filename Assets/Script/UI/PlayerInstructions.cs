using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstructions : MonoBehaviour
{
    [SerializeField] bool showInitialDialogue;
    [SerializeField] bool showMovementInstructions;
    [SerializeField] bool showOrbInstructions;
    [SerializeField] bool showTorchLightInstructions;
    [SerializeField] float showMovementInstructionsAfter = 2.5f;
    bool hasMoved = false;
    bool displayedMovementInstructions = false;
    InstructionPrinter printer;
    // Start is called before the first frame update
    void Start()
    {
        printer = GameObject.Find("InGameUI").GetComponent<InstructionPrinter>();
        if(showInitialDialogue)
        {
            StartCoroutine("ShowInitialDialogue");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasMoved && showMovementInstructions && (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")))
        {
            hasMoved = true;
            showMovementInstructions = false;
            if(displayedMovementInstructions)
            {
                printer.RemoveMovementInstructions();
            }
        }
    }

    IEnumerator ShowInitialDialogue(){
        yield return new WaitForSeconds(1f);
        printer.PrintInitialDialogue(1);
        yield return new WaitForSeconds(8f);

        printer.PrintInitialDialogue(2);
        yield return new WaitForSeconds(8f);

        printer.PrintInitialDialogue(3);
        yield return new WaitForSeconds(4f);

        printer.PrintInitialDialogue(4);
        yield return new WaitForSeconds(5f);

        if(showMovementInstructions)
        {
            StartCoroutine("ShowMovementInstructions");
            displayedMovementInstructions = true;
        }else
        {
            StartCoroutine("RemoveInstructions");
        }
    }

    IEnumerator ShowMovementInstructions() {
        yield return new WaitForSeconds(showMovementInstructionsAfter);
        if(!hasMoved)
        {
            printer.PrintMovementInstructions();
        }
    }

    IEnumerator RemoveInstructions() {
        printer.RemoveInstructions();
        yield return null;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "OrbInstructionTrigger" && showOrbInstructions)
        {
            StartCoroutine("ShowOrbInstructions");
        }

        if(other.gameObject.name == "TorchInstructionTrigger" && showTorchLightInstructions)
        {
            showTorchLightInstructions = false;
            printer.ShowTorchInstructions();
            StartCoroutine("RemoveInstructions");
        }
    }

    IEnumerator ShowOrbInstructions(){
        showOrbInstructions = false;
        printer.ShowOrbInstructions(1);
        yield return new WaitForSeconds(6f);
        printer.ShowOrbInstructions(2);
        yield return new WaitForSeconds(6f);
        StartCoroutine("RemoveInstructions");
    }
}
