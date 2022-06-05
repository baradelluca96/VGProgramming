using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWP = 0;
    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSpeed = 2f;
    bool isChasing = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!isChasing)
        {
            if(Vector3.Distance(transform.position, waypoints[currentWP].transform.position) < 3f)
            {
                currentWP = (currentWP + 1) % waypoints.Length;
            }

            Quaternion lookAtWaypont = Quaternion.LookRotation(waypoints[currentWP].transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookAtWaypont, Time.deltaTime * rotationSpeed);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    public void ChasePlayer()
    {
        isChasing = true;
    }

    public void ReturnToPath()
    {
        isChasing = false;
    }
}
