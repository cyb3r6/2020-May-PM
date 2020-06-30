using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    public GameObject collidingObject;      // save what we're touching
    public GameObject heldObject;           // save what we're holding

    public bool gripHeld;
    public bool isHeld;

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
    
    void Start()
    {
        
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
                    Grab();
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1) && gripHeld == true)
        {
            gripHeld = false;

            if (heldObject)
            {
                Release();
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && heldObject)
        {
            heldObject.BroadcastMessage("Interaction");
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

        heldObject.GetComponent<Rigidbody>().isKinematic = true;

    }

    private void Release()
    {
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
}
