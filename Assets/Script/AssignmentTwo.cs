using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AssignmentTwo : MonoBehaviour
{
    // Problem 1 counteract gravity
    private Rigidbody RigidBody;

    private void Start()
    {
        // Problem 1 counteract gravity
        RigidBody = GetComponent<Rigidbody>(); // get the current objects rigidbody component, that component is incharge of that objects gravity.
    }

    

    private void FixedUpdate()// for the longest time I did not realize why it was over correcting, it was because the normal update mas applying the counter force more times than normal gravity.
    {
        RigidBody.AddForce( -Physics.gravity, ForceMode.Acceleration); // this counters the gravity by applying an equal but opposite Aceleration to it, acceleration is not affected by mass in unity so you can change its mass and it counter acts gravity all the same
        RigidBody.velocity = new Vector3(0, 0, 0); // this resets the velocity, in case the object is already falling by the time this script is activated.
    }
}
