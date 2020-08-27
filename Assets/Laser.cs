using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float RotateSpeed = 1.0f;


    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Input.GetKey("left"))
        {
            gameObject.transform.Rotate(-RotateSpeed, 0.0f, 0.0f, Space.Self);
        }

        if (Input.GetKey("right"))
        {
            gameObject.transform.Rotate(RotateSpeed, 0.0f, 0.0f, Space.Self);
        }

        if (Input.GetKey("space"))
        {
            if (Physics.Raycast(transform.position, fwd, out hit))
            {
                hit.transform.SendMessage("HitByRay");
            }
        }

    }


}
