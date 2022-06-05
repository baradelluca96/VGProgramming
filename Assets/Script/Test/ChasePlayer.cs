using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    Transform target;
    bool isStillVisible = true;
    [SerializeField] float speed = 5f;
    bool canSeePlayer = false;
    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        FieldOfView fov = GetComponent<FieldOfView>();
        canSeePlayer = fov.canSeePlayer;
        target = fov.playerRef.transform;
        if (target != null && canSeePlayer)
        {
            if (Vector3.Distance(target.position, transform.position) > 10f)
            {
                FollowTarget();
            }else{
                FollowPath();
            }
        }else{
            FollowPath();
        }
    }

    void FollowTarget()
    {
        if (isStillVisible)
        {
            GetComponent<FollowWaypoint>().ChasePlayer();
            float step = speed * Time.deltaTime;
            Debug.Log(Vector3.MoveTowards(transform.position, target.position, step));
            body.MovePosition(Vector3.MoveTowards(transform.position, target.position, step));

            Vector3 relativePos = target.position - transform.position;
            body.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        }
    }

    void FollowPath()
    {
        GetComponent<FollowWaypoint>().ReturnToPath();
    }
}
