using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    private VRInput vrInputController;

    public GameObject collidingObject;      // save what we're touching
    public GameObject heldObject;           // save what we're holding

    public bool gripHeld;
    public bool isHeld;

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        // check that we exited the "colliding object" and not some other object 
        if (other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    void Awake()
    {
        vrInputController = GetComponent<VRInput>();
    }

    
    void Update()
    {
        if(vrInputController.gripValue > 0.8f && gripHeld == false)
        {
            gripHeld = true;

            if(collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;

                //Grab();
                AdvGrab();
            }
        }
        else if(vrInputController.gripValue < 0.8f && gripHeld == true)
        {
            gripHeld = false;

            if (heldObject)
            {
                //Release();
                AdvRelease();
            }
        }

        if(vrInputController.triggerValue > 0.8f && heldObject)
        {
            //heldObject.BroadcastMessage("Interaction");
        }
    }

    private void Grab()
    {
        heldObject.transform.SetParent(this.transform);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;

        var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
            grabbable.controller = vrInputController;
        }
    }

    private void Release()
    {
        var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbable)
        {
            grabbable.hand = null;
            grabbable.isBeingHeld = false;
            grabbable.controller = null;
        }

        // get rigidbody
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();

        // throw
        rb.velocity = vrInputController.handVelocity;
        rb.angularVelocity = vrInputController.handAngularVelocity;

        // reset heldObject        
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }

    private void AdvGrab()
    {
        Debug.Log("AdvGrab has been called");

        // create a fixed joint
        FixedJoint fj = gameObject.AddComponent<FixedJoint>();  // (typeof(FixedJoint)) as FixedJoint;
        fj.connectedBody = heldObject.GetComponent<Rigidbody>();
        fj.breakForce = 2000;
        fj.breakTorque = 2000;

        var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
            grabbable.controller = vrInputController;
        }

    }

    private void AdvRelease()
    {
        if (GetComponent<FixedJoint>())
        {
            var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
            if (grabbable)
            {
                grabbable.hand = null;
                grabbable.isBeingHeld = false;
                grabbable.controller = null;
            }

            Destroy(GetComponent<FixedJoint>());

            // get the rigidbody
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();

            // throw
            rb.velocity = vrInputController.handVelocity;
            rb.angularVelocity = vrInputController.handAngularVelocity;

            // reset heldObject
            heldObject = null;
        }
    }
}
