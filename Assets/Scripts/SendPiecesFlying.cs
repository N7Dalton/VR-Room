using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SendPiecesFlying : MonoBehaviour
{
    private float random;
    private Rigidbody rb;
    public AudioSource Bink;
    public AudioSource Shatter; 
    // Start is called before the first frame update
    public void Start()
    {
        Bink = this.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        random = UnityEngine.Random.Range(1f, 5f);
        Vector3 RandomVector3 = random * rb.velocity;
        
        rb.AddExplosionForce(random * 100, new Vector3(-10,0,0) ,20f ,1f);
        Shatter.Play();

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void OnCollisionEnter(Collision collision)
    {
        
       Bink.Play();
    }

}
