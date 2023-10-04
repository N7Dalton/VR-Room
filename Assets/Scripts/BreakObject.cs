using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    public AudioSource Bink;
    public bool canBreak = false;
    public Rigidbody objectToBreakRB;
    public GameObject objectToBreak;
    public GameObject brokenObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToBreakRB.velocity.magnitude > 4)
        {
            canBreak = true;

        }
    }

    public void OnCollisionEnter(Collision other)
    {
            Bink.Play();
        
        if (canBreak && other.transform.root.tag != "Player") 
        {
         
            Instantiate(brokenObject, objectToBreak.transform.position , Quaternion.identity);
            
            Destroy(objectToBreak);

        }
    }

}
