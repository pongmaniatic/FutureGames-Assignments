using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Wall", menuName = "Wall")]
public class Wall : ScriptableObject
{
    public int Health;
    public Color Color;
    public AudioClip GetHitAudio;
    public AudioClip DieAudio;
}
