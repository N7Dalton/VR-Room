
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sounds 
{
    public string name;

    [HideInInspector]
    public AudioSource source;

    public AudioClip DownForce;

    [Range(0f,1f)]
    public float volume;
    

}
