using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonerScript : MonoBehaviour
{

    private Animator Anim;


    public CapsuleCollider MainCollider;
    public GameObject MainRig;
    public Animator MainAnimator;
   
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
        ragdollColliders = MainRig.GetComponentsInChildren<Collider>();
        limbsRigidbodys = MainRig.GetComponentsInChildren<Rigidbody>();
    }

    public void ragdollModeOn()
    {

       MainAnimator.enabled = false;
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


        MainAnimator.enabled = true;
        MainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void Shoot()
    {
        
    }
    public void OnBecameVisible()
    {
        Shoot();
        Anim.Play("Shooting");
    }

    public void OnBecameInvisible()
    {
        Anim.Play("Idle");
    }
}
