using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUI : MonoBehaviour
{
    bool isOpen;
    GameObject canvas;
    public GameObject companion;
    public float companionUISpeed = 5f;

    public float companionDistance = 5f;
    public float companionDistanceSide = 2f;
    public float companionDistanceTop = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("InGameCanvas");
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("ToggleUI"))
        {
            isOpen = isOpen ? false : true;
        }

        canvas.SetActive(isOpen);

        if(isOpen) {
            // Debug.Log(companion.transform.position);
            GameObject camera = GameObject.Find("Main Camera");
            Vector3 targetPosition = (camera.transform.position + camera.transform.forward * companionDistance + camera.transform.up * companionDistanceTop + camera.transform.right * companionDistanceSide);
            float distance = Mathf.Clamp(Vector3.Distance(companion.transform.position, targetPosition), 0.005f, 100f);
            companion.transform.position = Vector3.MoveTowards(companion.transform.position, targetPosition, companionUISpeed * Time.deltaTime * distance);
        }
    }
}
