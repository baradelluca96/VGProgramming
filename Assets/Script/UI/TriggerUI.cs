using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerUI : MonoBehaviour
{
    bool isOpen;
    bool lockOpen;
    bool showAction;
    GameObject canvas;
    GameObject actionCanvas;
    public GameObject companion;
    public float companionUISpeed = 5f;

    public float UIcompanionDistance = 5f;
    public float UIcompanionDistanceSide = 2f;
    public float UIcompanionDistanceTop = 1.5f;
    string instructions;
    TMP_Text tMPtext;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("InGameCanvas");
        actionCanvas = GameObject.Find("CanvasInteract");
        actionCanvas.SetActive(false);
        tMPtext = GameObject.Find("CompanionText").GetComponent<TMP_Text>();
        isOpen = false;
        lockOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetButtonDown("ToggleUI"))
        {
            isOpen = (isOpen || lockOpen) ? false : true;
            canvas.SetActive(isOpen || lockOpen);
        }*/

        if(isOpen || lockOpen) {
            StepMoveCompanionOnUI();
        }
    }

    public void showUI(string policy)
    {
        lockOpen = true;
        canvas.SetActive(true);
        instructions = GetInstructionsText(policy);

        StartCoroutine("DisplayInstruction");
    }

    IEnumerator DisplayInstruction()
    {
        yield return new WaitForSeconds(1.5f); // After 1.5 sec
        tMPtext.text = "";
        AudioSource textSound = GetComponent<AudioSource>();
        foreach (char c in instructions)
        {
			tMPtext.text += c;
            if(isOpen || lockOpen)
            {
                float rand = Random.Range(-1f, 1f); 
                if(rand >= 0.4f || rand <= -0.4f)
                {
                    textSound.pitch = 1.2f + (rand * 0.5f);
                    textSound.Play();
                }
            }
			yield return new WaitForSeconds(0.02f);
        }
    }

    public void unlockUI()
    {
        StopCoroutine("DisplayInstruction");
        tMPtext.text = "";
        lockOpen = false;
        canvas.SetActive(false);
    }

    public void activateAction(){
        actionCanvas.SetActive(true);
    }

    public void disableAction(){
        actionCanvas.SetActive(false);
    }

    public void StepMoveCompanionOnUI(){
        GameObject camera = GameObject.Find("Main Camera");
        Vector3 targetPosition = (camera.transform.position + camera.transform.forward * UIcompanionDistance + camera.transform.up * UIcompanionDistanceTop + camera.transform.right * UIcompanionDistanceSide);
        float distance = Mathf.Clamp(Vector3.Distance(companion.transform.position, targetPosition), 0.005f, 100f);
        companion.transform.position = Vector3.MoveTowards(companion.transform.position, targetPosition, companionUISpeed * Time.deltaTime * distance);
    }

    private string GetInstructionsText(string policy){
        switch(policy)
        {
            case "movement":
                return "Forse il viaggio ti ha stordito, ricordati che per muoverti devi premere i tasti W,A,S o D! Per guardarti attorno usa il mouse!";

            case "orbInstructions":
                return "Questa sembra un fonte di energia sufficiente per un viaggio solo!";

            case "torchInstructions":
                return "Ricordati che ho una luce integrata, se vuoi attivarla premi il tasto Q!";

            default:
                return "Unhandled case: " + policy;
        }
    }
}
