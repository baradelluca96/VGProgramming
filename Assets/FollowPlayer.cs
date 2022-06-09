using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    public bool uiTriggered = false;

    [SerializeField] float forward = -2f;
    [SerializeField] float up = 3f;
    [SerializeField] float right = 2f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(!uiTriggered)
        {
            Vector3 targetPosition = (player.transform.position + player.transform.forward * -2f + player.transform.up * 3f + player.transform.right * 2f);
            float distance = Mathf.Clamp(Vector3.Distance(transform.position, targetPosition), 0.005f, 100f);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5f * Time.deltaTime * distance);
        }
    }
}
