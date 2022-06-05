using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;

    [Range(0, 360f)]
    public float angle;

    public GameObject playerRef;
    
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer; 
    void Start()
    {
        playerRef = GameObject.Find("Player");
        StartCoroutine("FOVRoutine");
        canSeePlayer = false;
    }

    private IEnumerator FOVRoutine() {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while(true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

Debug.Log(rangeChecks);
        if (rangeChecks.Length > 0)
        {
            Transform target = rangeChecks[0].transform; // Only the player is returned;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                }else{
                    canSeePlayer = false;
                }
            }else
            {
                canSeePlayer = false;
            }
        }else{
            canSeePlayer = false;
        }
    }
}
