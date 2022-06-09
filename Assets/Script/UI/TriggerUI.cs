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
            companion.GetComponent<FollowPlayer>().uiTriggered = true;
            StepMoveCompanionOnUI();
        }else{
            companion.GetComponent<FollowPlayer>().uiTriggered = false;
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
        yield return new WaitForSeconds(.5f); // After 1.5 sec
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
        GameObject camera = GameObject.Find("FirstPersonCam");
        Vector3 targetPosition = (camera.transform.position + camera.transform.forward * UIcompanionDistance + camera.transform.up * UIcompanionDistanceTop + camera.transform.right * UIcompanionDistanceSide);
        float distance = Mathf.Clamp(Vector3.Distance(companion.transform.position, targetPosition), 0.005f, 100f);
        companion.transform.position = Vector3.MoveTowards(companion.transform.position, targetPosition, companionUISpeed * Time.deltaTime * distance);
    }

    private string GetInstructionsText(string policy){
        switch(policy)
        {
            case "movement":
                return "Forse il viaggio ti ha stordito, ricordati che per muoverti devi premere i tasti W,A,S o D! Per guardarti attorno usa il mouse!";

            case "orbInstructions1":
                return "Questa sembra un fonte di energia sufficiente per un viaggio solo! Quel simbolo è uno dei nostri talismani! Dobbiamo trovarlo.";

            case "orbInstructions2":
                return "Avvicinati e prova a premere E per fare in modo che io possa sfruttare l'energia per viaggiare!";

            case "torchInstructions":
                return "Sembra piuttosto buio! Ricordati che ho una luce integrata, se vuoi attivarla premi il tasto Q!";
            case "dialogue1":
                return "Ehi, pare tu abbia perso la memoria, un'anomalia nel viaggio temporale ci ha fatto uscire di rotta e ora la nave è fuori uso.";
            case "dialogue2":
                return "Dobbiamo ritrovare i talismani per il viaggio, li ho identificati e sono dispersi nel tempo, precisamente in 3 luoghi e tempi diversi.";
            case "dialogue3":
                return "Rilevo alcune fonti di energia nelle vicinanze...";
            case "dialogue4":
                return "... forse possiamo sfruttarle per viaggiare nel tempo e recuperare i talismani per riprendere il viaggio.";

            case "labDialogue1":
                return "Siamo finiti in una zona misteriosa. Attenzione a non cadere!";
            case "labDialogue2":
                return " Sembra ci sia un ingresso laggiù. Il segnale proviene dall'interno di quella struttura.";

            case "oxygenInstructions":
                return "Rilevo una bassissima concentrazione di ossigeno all'interno. Preparati a trattenere il respiro!";

            case "villageDialogue1":
                return "Sembra siamo finiti in un villaggio disabitato... Dobbiamo trovare il talismano del sole! Aspetta... Oh no!";
            case "villageDialogue2":
                return "Sembra che non siamo soli! Ti stanno cercando, forse per qualcosa che hai dimenticato di aver fatto!";
            case "villageDialogue3":
                return "Cerca di non farti vedere, e se ti vedono nasconditi!";
            
            case "runDialogue1":
                return "Rilevo il pezzo non lontano da qui...";
            case "runDialogue2":
                return "Per correre tieni premuto SHIFT. Ho il sospetto ti servirà!";

            case "updateDialogue":
                bool runComplete = PlayerPrefs.GetInt("Run") > 0;
                bool villageComplete = PlayerPrefs.GetInt("Village") > 0;
                bool pyramidComplete = PlayerPrefs.GetInt("Pyramid") > 0;

                int sum = PlayerPrefs.GetInt("Run") + PlayerPrefs.GetInt("Village") + PlayerPrefs.GetInt("Pyramid");
                string value = "Abbiamo preso ";
                if(sum < 2) // Only one level complete
                {
                    if(runComplete)
                    {
                        value += "la foglia! Mancano il sole e la croce.";
                    }

                    if(villageComplete)
                    {
                        value += "il sole! Mancano la foglia e la croce.";
                    }

                    if(pyramidComplete)
                    {
                        value += "la croce! Mancano la foglia e il sole.";
                    }
                }else{ // Two levels complete
                    if(!runComplete)
                    {
                        value += "il sole e la croce. Manca solo la foglia!";
                    }

                    if(!villageComplete)
                    {
                        value += "la foglia e la croce. Manca solo il sole!";
                    }

                    if(!pyramidComplete)
                    {
                        value += "la foglia e il sole. Manca solo la croce!";
                    }
                }

                return value;
            default:
                return "Unhandled case: " + policy;
        }
    }
}
