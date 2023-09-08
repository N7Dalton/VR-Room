using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Swing : MonoBehaviour
{
    public Transform startSwingHand;
    public float maxDistance = 35f;
    public LayerMask swingableLayer;

    public Transform predictionPoint;
    private Vector3 swingPoint;

    public LineRenderer lineRenderer;
    public LineRenderer canHitRen;
    public bool hasHit;

    public InputActionProperty swingAction;
    public InputActionProperty boostAction;
    public InputActionProperty OpenUIAction;

    public float pullingStrength = 500;
    public Rigidbody playerRB;
    private SpringJoint joint;
    public float maxSpeed =50;
    public Camera cam;
    public bool canBoost = false;
    public float BoostAmount = 2f;
    public float maxBoostAmount = 2f;
    public GameObject UI;
    public bool UIOpened = false;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        if (boostAction.action.WasPressedThisFrame() && canBoost)
        {
            Boost();
        }
        DrawRopes();
        GetSwingPoint();

        if (swingAction.action.WasPressedThisFrame())
        {
            StartSwing();
        }
        else if (swingAction.action.WasReleasedThisFrame())
        {
            StopSwing();
        }

        if (playerRB.velocity.magnitude > maxSpeed)
        {
            playerRB.velocity = Vector3.ClampMagnitude(playerRB.velocity, maxSpeed);
        }

        if (OpenUIAction.action.WasPressedThisFrame())       
        {
            UIOPEN();
        }
       
                
            
    }
        public void StartSwing()
    {
        if(hasHit)
        {
            joint = playerRB.gameObject.AddComponent<SpringJoint>();
           canBoost = true;
            joint.autoConfigureConnectedAnchor = false; //
            joint.connectedAnchor = swingPoint;

            BoostAmount = maxBoostAmount;

            float distance = Vector3.Distance(playerRB.position, swingPoint);
            joint.maxDistance = distance;

            joint.spring = 20f;
            joint.damper = 10f;
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
        if (BoostAmount > 0)
        {
            Vector3 direction = (cam.transform.forward).normalized;
            playerRB.AddForce(direction * pullingStrength * Time.deltaTime, ForceMode.VelocityChange);

            float distance = Vector3.Distance(playerRB.position, swingPoint);
            joint.maxDistance = distance;
           
            BoostAmount = BoostAmount -1;
        }
       
    }
    public void UIOPEN()
    {
        if (UIOpened)
        {
            
            UI.SetActive(false);
            UIOpened = false;
        }
        else
        {
            
            UI.SetActive(true);
            UIOpened = true;
        }
    }
}
