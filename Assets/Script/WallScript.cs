using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private int CurrentHealth;
    private AudioClip GetHitSound;
    private AudioClip DieSound;
    private GameObject LaserObject;
    private Laser LaserScript;
    public AudioSource AudioSource;
    public Wall Wall;

    private void Start()
    {
        LaserObject = GameObject.FindGameObjectWithTag("Laser");
        LaserScript = LaserObject.GetComponent<Laser>();
        GetHitSound = Wall.GetHitAudio;
        DieSound = Wall.DieAudio;
        CurrentHealth = Wall.Health;
        gameObject.GetComponent<Renderer>().material.color = Wall.Color;
    }
    private void FixedUpdate()
    {
        if (CurrentHealth <= 0)
        {
            AudioSource.PlayOneShot(DieSound, 0.2f);
            Destroy(gameObject, 1);
            CurrentHealth = 1000;
        }
    }

    void HitByRay(int damage)
    {
        AudioSource.PlayOneShot(GetHitSound, 0.2f);
        CurrentHealth -= damage;
    }

}
