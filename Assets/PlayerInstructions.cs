using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstructions : MonoBehaviour
{
    [SerializeField] bool showMovementInstructions;
    [SerializeField] bool showOrbInstructions;
    [SerializeField] float showMovementInstructionsAfter = 2.5f;
    bool hasMoved = false;
    InstructionPrinter printer;
    // Start is called before the first frame update
    void Start()
    {
        printer = GameObject.Find("InGameUI").GetComponent<InstructionPrinter>();
        if(showMovementInstructions)
        {
            Debug.Log("STARTING COROUTINE");
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

    IEnumerator RemoveOrbInstrucitons() {
        yield return new WaitForSeconds(8f);
        printer.RemoveOrbInstructions();
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "OrbInstructionTrigger" && showOrbInstructions)
        {
            showOrbInstructions = false;
            printer.ShowOrbInstructions();
            StartCoroutine("RemoveOrbInstrucitons");
        }
    }
}
