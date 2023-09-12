using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IsGrabbed : MonoBehaviour
{
    public XRGrabInteractable interactable;
 
    public GameObject Mask;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.isSelected)
        {
            Mask.gameObject.layer = LayerMask.NameToLayer("MaskOn");

        }
    }
}
