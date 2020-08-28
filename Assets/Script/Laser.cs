using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float RotateSpeed = 1.0f;// this is how fast the laser gun rotates.
    private float targetTime = 0.0f; // this is the time between shots, starts at 0 but its set to 1 second after each raycast shot.
    private bool AbleToShoot = true; // this is true if you can shoot a raycast.
    public GameObject LaserVisualizer; // this is just a red tube that appears to show where the raycast went through, it does nothing, just to visualize, it was faster than trying to draw a line for me.
    private int LaserMaxDamage = 3; // this is the damage the first wall will recive, every wall after it will recive 1 les damage until it reaches a limit of 0.

    void Update()// this is mainly used for the timer between shots.
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f){ AbleToShoot = true; }
    }

    void FixedUpdate()
    {
        LaserVisualizer.SetActive(false);// this resets the laser visualizer so its invisible(because is inactive).
        RaycastHit[] hits;// this array will hold all the wall that are hit by the raycast
        Vector3 fwd = transform.TransformDirection(Vector3.forward); // this determines the direction to shoot the raycast.
        if (Input.GetKey("left")){gameObject.transform.Rotate(-RotateSpeed, 0.0f, 0.0f, Space.Self);}// this allows to rotate the laser gun
        if (Input.GetKey("right")){gameObject.transform.Rotate(RotateSpeed, 0.0f, 0.0f, Space.Self);}// this allows to rotate the laser gun
        if (Input.GetKey("space"))//space is used to shoot the raycast
        {
            if (AbleToShoot == true)//only shoot when its allowed.
            {
                int LaserCurrentDamage = LaserMaxDamage;// resets the damage for each raycast shot.
                hits = Physics.RaycastAll(transform.position, fwd, 40.0F);// this shoots the raycast and saves all hits in the array, also it overrrides tha prior array.
                for (int i = 0; i < hits.Length; i++)// this goes trough each wall it hit in order of what wall was hit first.
                {
                    RaycastHit hit = hits[i];// just to not write [i] that one time.
                    var distance = hits[i].distance;
                    Debug.Log("hit number " + i  + " is a total of " + distance + " arbetrary units away from laser");// to show that the order of the array is set from closest to further to the dev who views it.
                    LaserVisualizer.SetActive(true);// shows the laser visualizer
                    AbleToShoot = false;// just so it does not shoot 100 shots in a microsecond.
                    targetTime = 1.0f;// resets the timer to 1 second to be able to shoot a raycast again
                    hit.transform.SendMessage("HitByRay", LaserCurrentDamage);// sends a message to the wall to take the correct amount of damage and make the sounds of being hit.
                    LaserCurrentDamage -= 1;// lowers damage for the next wall.
                    if (LaserCurrentDamage < 0){LaserCurrentDamage = 0;}// caps the damage at 0-
                }
            }
        }
    }
}
