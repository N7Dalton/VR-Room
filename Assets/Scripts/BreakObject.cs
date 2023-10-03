using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
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
        if(canBreak && other.transform.root.tag != "Player") 
        {
            Debug.Log("cab break  and istrigger");
            Instantiate(brokenObject, objectToBreak.transform.position , Quaternion.identity);
            
            Destroy(objectToBreak);

        }
    }

}
