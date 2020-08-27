using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentTwo : MonoBehaviour
{

    public Vector3 PositionCenterOfMass;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PositionCenterOfMass = rb.centerOfMass;
        Debug.Log(" centro de masa: "+ PositionCenterOfMass);
    }


}
