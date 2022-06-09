using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidGameManager : MonoBehaviour
{
    [Header("Village Assets")]
    [SerializeField] GameObject villageSymbol1;
    [SerializeField] GameObject villageSymbol2;
    [SerializeField] GameObject villageLantern;
    [SerializeField] GameObject villageOrb;

    [Header("Run Assets")]
    [SerializeField] GameObject runSymbol1;
    [SerializeField] GameObject runSymbol2;
    [SerializeField] GameObject runLantern;
    [SerializeField] GameObject runOrb;

    [Header("Pyramid Assets")]
    [SerializeField] GameObject pyramidSymbol1;
    [SerializeField] GameObject pyramidLantern;
    [SerializeField] GameObject pyramidOrb;
 
    // Start is called before the first frame update
    void Start()
    {
        bool runComplete = PlayerPrefs.GetInt("Run") > 0;
        bool villageComplete = PlayerPrefs.GetInt("Village") > 0;
        bool pyramidComplete = PlayerPrefs.GetInt("Pyramid") > 0;

        if(runComplete)
        {
            DisableAssets("run");
        }

        if(villageComplete)
        {
            DisableAssets("village");
        }

        if(pyramidComplete)
        {
            DisableAssets("pyramid");
        }
        
    }

    void DisableAssets(string level)
    {
        switch(level)
        {
            case "run":
                Destroy(runSymbol1);
                Destroy(runSymbol2);
                runLantern.gameObject.tag = "Untagged";
                runOrb.GetComponent<AudioSource>().Stop();
                break;
            case "village":
                Destroy(villageSymbol1);
                Destroy(villageSymbol2);
                villageLantern.gameObject.tag = "Untagged";
                villageOrb.GetComponent<AudioSource>().Stop();
                break;
            case "pyramid":
                Destroy(pyramidSymbol1);
                pyramidLantern.gameObject.tag = "Untagged";
                pyramidOrb.GetComponent<AudioSource>().Stop();
                break;
            default:
                break;
        }
    }
}
