using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowards : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
      this.transform.LookAt(GameObject.FindWithTag("Player").transform.position); 
        //this.gameObject.transform.Translate(this.transform.forward * .01f);
    }
}
