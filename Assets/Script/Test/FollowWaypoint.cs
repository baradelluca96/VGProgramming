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

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isChasing)
        {
            Walk();
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
        Run();
        isChasing = true;
    }

    public void ReturnToPath()
    {
        Walk();
        isChasing = false;
    }

    private void Walk()
    {
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        anim.SetFloat("Speed", 0.98f, 0.1f, Time.deltaTime);
    }
}
