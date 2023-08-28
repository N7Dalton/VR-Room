using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LayerChanger()
    {
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        gameObject.layer = LayerIgnoreRaycast;
    }
    public void LayerDechanger()
    {
        int LayerDefault = LayerMask.NameToLayer("Default");
        gameObject.layer = LayerDefault;
    }
}
