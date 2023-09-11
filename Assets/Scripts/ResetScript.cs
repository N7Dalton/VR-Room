using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public Rigidbody XRrig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetPlayer()
    {
       XRrig.transform.position = new Vector3(0,0,0);
       XRrig.velocity = new Vector3(0,0,0);
    }
    public void Quit()
    {
        Debug.Log("L");
    }
}
