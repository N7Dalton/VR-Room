using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Swing : MonoBehaviour
{
    public Transform startSwingHand;
    public float maxDistance = 35f;
    public LayerMask swingableLayer;

    public Transform predictionPoint;
    private Vector3 swingPoint;

    public bool hasHit;

    public InputActionProperty swingAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetSwingPoint();

        if(swingAction.action.WasPressedThisFrame())
        {
               
        }
        else if(swingAction.action.WasReleasedThisFrame())
        {
        
        }

      
    }
    public void StartSwing()
    {

    }

    public void StopSwing()
    {

    }
    public void GetSwingPoint()
    {
        RaycastHit raycastHit;

       hasHit =  Physics.Raycast(startSwingHand.position, startSwingHand.forward, out raycastHit, maxDistance, swingableLayer);
        if(hasHit)
        {
            swingPoint = raycastHit.point;
            predictionPoint.gameObject.SetActive(true);
            predictionPoint.position = swingPoint;
        }
        else
        {
            predictionPoint.gameObject.SetActive(false);
        }
    }
}
