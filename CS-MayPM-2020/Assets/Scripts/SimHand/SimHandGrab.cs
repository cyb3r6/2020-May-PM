using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    public GameObject collidingObject;      // save what we're touching
    public GameObject heldObject;           // save what we're holding

    public bool gripHeld;
    public bool isHeld;
    public bool isTPressed;

    private Vector3 handVelocity;
    private Vector3 previousPosition;

    private Vector3 handAngularVelocity;
    private Vector3 previousAngularRotation;

    public float throwForce;

    [SerializeField]
    private Transform snapPosition;

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
    
    void Update()
    {
        // check for mouse input
        if (Input.GetKey(KeyCode.Mouse1) && gripHeld == false)
        {
            gripHeld = true;

            if (collidingObject)
            {
                if (collidingObject.GetComponent<Rigidbody>())
                {
                    heldObject = collidingObject;

                    // do the grabbing!
                    //Grab();
                    AdvGrab();
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1) && gripHeld == true)
        {
            gripHeld = false;

            if (heldObject)
            {
                //Release();
                AdvRelease();
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            isTPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            isTPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && heldObject)
        {
            //heldObject.BroadcastMessage("Interaction");
        }

        handVelocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        handAngularVelocity = (this.transform.eulerAngles - previousAngularRotation) / Time.deltaTime;
        previousAngularRotation = this.transform.eulerAngles;
    }

    private void Grab()
    {
        Debug.Log("Grab has been called");

        heldObject.transform.SetParent(snapPosition);
        heldObject.transform.localPosition = Vector3.zero;

        // the object doesn't necessarily need to be isKinematic, this is a preference!
        heldObject.GetComponent<Rigidbody>().isKinematic = true;

        var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
            grabbable.simHandController = this;

            heldObject.transform.localPosition += grabbable.grabOffset;

        }
    }

    private void Release()
    {
        var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
        if (grabbable)
        {
            grabbable.hand = null;
            grabbable.isBeingHeld = false;
            grabbable.simHandController = null;
        }

        // get the rigidbody
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();

        // throw
        rb.velocity = handVelocity * throwForce;
        rb.angularVelocity = handAngularVelocity * throwForce;

        // reset heldObject        
        rb.isKinematic = false;
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

        var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
            grabbable.simHandController = this;

            heldObject.transform.localPosition += grabbable.grabOffset;

        }

    }

    private void AdvRelease()
    {
        if (GetComponent<FixedJoint>())
        {
            var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
            if (grabbable)
            {
                grabbable.hand = null;
                grabbable.isBeingHeld = false;
                grabbable.simHandController = null;
            }

            Destroy(GetComponent<FixedJoint>());

            // get the rigidbody
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();

            // throw
            rb.velocity = handVelocity * throwForce;
            rb.angularVelocity = handAngularVelocity * throwForce;

            // reset heldObject
            heldObject = null;
        }
    }
}
