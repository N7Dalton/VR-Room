using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundMan : MonoBehaviour
{
    
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
         click = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound()
    {
        click.Play(0);
    }
}
