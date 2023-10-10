using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonerScript : MonoBehaviour
{

    public Animator Anim;


    public CapsuleCollider MainCollider;
    public GameObject MainRig;
    //public Animator MainAnimator;
   
    // Start is called before the first frame update
    void Start()
    {
        GetRagdollThings();
        ragdollModeOff();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collision)
    {
       
        if(collision.gameObject.tag == "Player")
        {
            
            ragdollModeOn();
        }
    }
    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidbodys;
    void GetRagdollThings()
    {
        //just gets all of the Rigidbodies and Colliders at the start(Ignore)
        ragdollColliders = MainRig.GetComponentsInChildren<Collider>();
        limbsRigidbodys = MainRig.GetComponentsInChildren<Rigidbody>();
    }

    public void ragdollModeOn()
    {
        Debug.Log("RAGDOLL MODE GO!");
       Anim.enabled = false;
        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = true;

        }
        foreach (Rigidbody rigidbody in limbsRigidbodys)
        {
            rigidbody.isKinematic = false;

        }


        
        MainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void ragdollModeOff()
    {
        foreach(Collider collider in ragdollColliders) 
        { 
            collider.enabled = false; 
        
        }
        foreach (Rigidbody rigidbody in limbsRigidbodys)
        {
            rigidbody.isKinematic = true;

        }


        Anim.enabled = true;
        MainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void Shoot()
    {
        Anim.SetBool("IsShooting", true);
    }
   

    
}
