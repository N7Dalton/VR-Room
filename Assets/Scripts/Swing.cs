using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Rendering;

public class Swing : MonoBehaviour
{
    public TurnOnUI MaskUIScript;
    public Transform startSwingHand;
    public float maxDistance = 35f;
    public LayerMask swingableLayer;
    public SphereCollider IsGroundedSphere;
    public bool isGrounded;



    public Transform predictionPoint;
    private Vector3 swingPoint;

    public LineRenderer lineRenderer;
    public LineRenderer canHitRen;
    public bool hasHit;

    public InputActionProperty swingAction;
    public InputActionProperty boostAction;
    public InputActionProperty OpenUIAction;
    public InputActionProperty jumpAction;
    

    public Rigidbody Hand;


    public float chargeSpeed;
    public float chargeTime;
    public bool isCharging = false;
    public bool isPressingB = false;
    public bool canJump = false;

    public float pullingStrength = 1000;
    public Rigidbody playerRB;
    private SpringJoint joint;
    public float maxSpeed = 125;
    public Camera cam;

    public GameObject UI;
    
    public bool UIOpened = false;
    public float distance;
    public AudioSource FWIP;
    // Start is called before the first frame update
    void Start()
    {
        canHitRen = Hand.gameObject.GetComponent<LineRenderer>();
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
        if (MaskUIScript.maskOn)
        {
            canHitRen.enabled = true;
        }
        else
        {
            canHitRen.enabled = false;
        }
           

    }
    public void OnCollisionStay(Collision collision)
    {




    }
    public void StartSwing()
    {
        if (hasHit)
        {
            joint = playerRB.gameObject.AddComponent<SpringJoint>();

            joint.autoConfigureConnectedAnchor = false; //
            joint.connectedAnchor = swingPoint;



            float distance = Vector3.Distance(playerRB.position, swingPoint);
            joint.maxDistance = distance / 1.25f;

            joint.spring = 20f;
            joint.damper = 10f;
            joint.massScale = 4.5f;
            FWIP.Play();
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
            //canHitRen.gameObject.SetActive(false);
            return;
        }

        RaycastHit raycastHit;

        hasHit = Physics.Raycast(startSwingHand.position, startSwingHand.forward, out raycastHit, maxDistance, swingableLayer);
        if (hasHit)
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
    public void DrawRopes()
    {
        if (!joint)
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
        playerRB.AddForce(direction * pullingStrength * Time.deltaTime, ForceMode.VelocityChange);

        float distance = Vector3.Distance(playerRB.position, swingPoint);
        joint.maxDistance = distance / 1.25f;


    }
    public void jump()
    {
        playerRB.velocity += new Vector3(0, 20, 0);
        isCharging = false;
        chargeTime = 0;
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
