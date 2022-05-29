using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderFollowPath : MonoBehaviour
{
    int currentForceCode = 0;
    // Start is called before the first frame update
    void Start()
    {
      Debug.Log(transform.right);
      Debug.Log(Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        if (currentForceCode == 0)
        {
          rigidBody.AddForce(Vector3.right * -2);
        }else if (currentForceCode == 1)
        {
          rigidBody.AddForce(Vector3.forward * -3);
        }
        else if (currentForceCode == 2)
        {
          rigidBody.AddForce(Vector3.right * 4);
        }
        else
        {
          rigidBody.AddForce(Vector3.forward * 5);
        }
        Debug.Log(rigidBody.velocity);
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        other.enabled = false;
        rigidBody.velocity = Vector3.zero;
        Debug.Log(rigidBody.rotation);

        currentForceCode += 1;
    }
}
