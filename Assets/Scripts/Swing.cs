using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Swing : MonoBehaviour
{
    public Transform startSwingHand;

    [Tooltip("The max distance that the webs can go")]
    public float maxDistance = 35f;
    public LayerMask swingableLayer;

    public Transform predictionPoint;
    private Vector3 swingPoint;

    public LineRenderer lineRenderer;
    public LineRenderer canHitRen;
    public bool hasHit;

    public InputActionProperty swingAction;
    public InputActionProperty boostAction;

    [Tooltip("the force that pulls you when you press R3")]
    public float pullingStrength = 500;
    public Rigidbody playerRB;
    private SpringJoint joint;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (boostAction.action.WasPressedThisFrame())
        {
            Boost();
        }
        DrawRopes();
        GetSwingPoint();

        if(swingAction.action.WasPressedThisFrame())
        {
            StartSwing();
        }
        else if(swingAction.action.WasReleasedThisFrame())
        {
            StopSwing();
        }

        
        
    }
    public void StartSwing()
    {
        if(hasHit)
        {
            joint = playerRB.gameObject.AddComponent<SpringJoint>();
           
            joint.autoConfigureConnectedAnchor = false; //
            joint.connectedAnchor = swingPoint;
            

            float distance = Vector3.Distance(playerRB.position, swingPoint);
            joint.maxDistance = distance;

            joint.spring = 15f;
            joint.damper = 7;
            joint.massScale = 4.5f;
        }
    }

    public void StopSwing()
    {
        Destroy(joint);
    }
    public void GetSwingPoint()
    {
        if (joint)
        {
            predictionPoint.gameObject.SetActive(false);
            return;
        }

        RaycastHit raycastHit;

       hasHit =  Physics.Raycast(startSwingHand.position, startSwingHand.forward, out raycastHit, maxDistance, swingableLayer);
        if(hasHit)
        {
            swingPoint = raycastHit.point;
            predictionPoint.gameObject.SetActive(true);
            canHitRen.sharedMaterial.SetColor("Defualt-Line", Color.green);
            predictionPoint.position = swingPoint;
        }
        else
        {
            predictionPoint.gameObject.SetActive(false);
            canHitRen.sharedMaterial.SetColor("Defualt-Line", Color.red);
        }
    }
    public void DrawRopes()
    {
       if(!joint)
        {
            lineRenderer.enabled = false;
        }
        else
        {
            lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, startSwingHand.position);
            lineRenderer.SetPosition(1, swingPoint);
        }
    }
    public void Boost()
    {
        
        if (!joint)
        {
            return;
        }
        Vector3 direction = (cam.transform.forward).normalized;
        playerRB.AddForce(direction * pullingStrength* Time.deltaTime,ForceMode.VelocityChange );

        float distance = Vector3.Distance(playerRB.position, swingPoint);
        joint.maxDistance = distance;
    }
}
