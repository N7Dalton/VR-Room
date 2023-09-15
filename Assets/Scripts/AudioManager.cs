using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    public Sounds[] sound;
    void Awake()
    {
        foreach (Sounds s in sound)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.DownForce;

            s.source.volume = s.volume;
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
         Sounds s = Array.Find(sound, sound => sound.name == name);
        s.source.Play();


    }
    public void playDownforce() 
    
    {
        Play("(Downforce) Pole Position");
    }
    public void Pause()
    {
       foreach (Sounds s in sound)
        {
            s.source.Pause();
        }
    }
}
