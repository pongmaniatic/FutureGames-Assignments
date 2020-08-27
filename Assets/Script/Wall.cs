using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : ScriptableObject

{
    private int health = 3;

    private void FixedUpdate()
    {

        if (health <= 0)
        {
            Destroy(this, 5);
        }
    }

    void HitByRay()
    {
        health -= 1;
    }
}
