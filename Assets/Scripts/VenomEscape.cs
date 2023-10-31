using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomEscape : MonoBehaviour
{
    public GameObject mainRig; //this is the parent game object
    public Animator Anim; // this will turn on and off animations
    public CapsuleCollider MainCollider; //this is the capsule collider that when you collide with it then it will trigger ragdoll mode
                                        //its a seperate capsule collider you have to add to the whole model for collisions
    private Vector3 spawnPoint = new Vector3(130, 310.40f, 187);
    private Vector3 Cage = new Vector3(0, 0, 5);
    public GameObject Venom;
    public bool venomInCage;
    public AudioSource venomEscapedNoise;
    public AudioSource venomTaunt;
    public GameObject Pling;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("VenomEscapeEvent", 20f, 100f);
        GetRagdollThings();
        ragdollModeOff();
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "PlayerHead")
        {

            ragdollModeOn();
        }
    }
    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidbodys;
    void GetRagdollThings()
    {
        //just gets all of the Rigidbodies and Colliders at the start(Ignore)
        ragdollColliders = mainRig.GetComponentsInChildren<Collider>();
        limbsRigidbodys = mainRig.GetComponentsInChildren<Rigidbody>();
    }
    public void ragdollModeOn()
    {
        rb.constraints = RigidbodyConstraints.None;
        Debug.Log("RAGDOLL MODE GO!");
        Anim.enabled = false;
        StartCoroutine("VenomHit");
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
        foreach (Collider collider in ragdollColliders)
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
    public IEnumerator VenomHit()
    {
        Debug.Log("Venom hit co routine");
        yield return new WaitForSecondsRealtime(10f);
        ragdollModeOff();
        Venom.transform.position = Cage;
        Pling.SetActive(false);
        rb.constraints = RigidbodyConstraints.None;
    }
    public void VenomEscapeEvent()
    {
       if (Venom.transform.position != spawnPoint)
        {
           
                Pling.SetActive(true);
                venomEscapedNoise.Play();
                Venom.transform.position = spawnPoint;
                Debug.Log("Venom Escaped!");
                venomInCage = true;
        }
        else
        {
                venomTaunt.Play();
                Debug.Log("VENOM IS ALREADY OUT GO GET HIM");
                venomInCage = false;    
        }
    }
}
