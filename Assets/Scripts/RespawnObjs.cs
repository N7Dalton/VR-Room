using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObjs : MonoBehaviour
{
    public GameObject mask;
    public GameObject phone;
    public Vector3 masktp;
    public Vector3 phonetp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (mask != null) 
        
        {
            mask.transform.position = masktp;
        }
        if (phone != null)

        {
            phone.transform.position = phonetp;
        }
    }
}
