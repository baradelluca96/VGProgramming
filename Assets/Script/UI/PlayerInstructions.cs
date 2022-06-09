using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstructions : MonoBehaviour
{
    [SerializeField] bool showInitialDialogue;
    [SerializeField] bool showMovementInstructions;
    [SerializeField] bool showOrbInstructions;
    [SerializeField] bool showTorchLightInstructions;
    [SerializeField] bool showLabDialogue;
    [SerializeField] bool showOxygenInstructions;
    [SerializeField] bool showVillageDialogue;
    [SerializeField] bool showRunDialogue;
    [SerializeField] bool updatePlayerStatus;
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
        }else if(showLabDialogue)
        {
            StartCoroutine("ShowInitialLabDialogue");
        }else if(showVillageDialogue)
        {
            StartCoroutine("ShowVillageDialogue");
        }else if(showRunDialogue)
        {
            StartCoroutine("ShowRunDialogue");
        }else if(updatePlayerStatus)
        {
            StartCoroutine("UpdateMidGameStatus");
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
        yield return new WaitForSeconds(2.5f);
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

        if(other.gameObject.name == "TorchInstructionsTrigger" && showTorchLightInstructions)
        {
            StopCoroutine("DelayedRemoveInstructions");
            showTorchLightInstructions = false;
            printer.ShowTorchInstructions();
            StartCoroutine("DelayedRemoveInstructions");
        }

        if(other.gameObject.name == "OxygenInstructionsTrigger" && showOxygenInstructions)
        {
            StopCoroutine("DelayedRemoveInstructions");
            showOxygenInstructions = false;
            printer.ShowOxygenInstructions();
            StartCoroutine("DelayedRemoveInstructions");

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

    IEnumerator ShowInitialLabDialogue() {
        yield return new WaitForSeconds(1f);
        printer.PrintInitialLabDialogue(1);
        yield return new WaitForSeconds(8f);

        printer.PrintInitialLabDialogue(2);
        yield return new WaitForSeconds(8f);

        StartCoroutine("RemoveInstructions");
    }

    IEnumerator ShowVillageDialogue() {
        yield return new WaitForSeconds(1f);
        printer.PrintVillageDialogue(1);
        yield return new WaitForSeconds(8f);

        printer.PrintVillageDialogue(2);
        yield return new WaitForSeconds(8f);

        printer.PrintVillageDialogue(3);
        yield return new WaitForSeconds(8f);

        StartCoroutine("RemoveInstructions");
    }

    IEnumerator DelayedRemoveInstructions(){
        yield return new WaitForSeconds(8f);
        StartCoroutine("RemoveInstructions");
    }

    IEnumerator ShowRunDialogue(){
        yield return new WaitForSeconds(1f);
        printer.PrintRunDialogue(1);
        yield return new WaitForSeconds(5f);
        printer.PrintRunDialogue(2);
        yield return new WaitForSeconds(6f);
        StartCoroutine("RemoveInstructions");
    }

    IEnumerator UpdateMidGameStatus(){
        yield return new WaitForSeconds(1f);
        printer.PrintUpdateDialogue();
        yield return new WaitForSeconds(6f);
        StartCoroutine("RemoveInstructions");
    }
}
