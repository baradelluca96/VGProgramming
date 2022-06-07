using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowWaypoint : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWP = 0;
    NavMeshAgent navMeshAgent;
    FieldOfView fov;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        fov = GetComponent<FieldOfView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fov.canSeePlayer)
        {
            navMeshAgent.destination = fov.playerRef.transform.position;
        }else{
            if(Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 3f)
            {
                currentWP = (currentWP + 1) % waypoints.Length;
            }

            navMeshAgent.destination = waypoints[currentWP].transform.position;
        }
    }
}
