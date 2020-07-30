using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalObject : MonoBehaviour
{
    public Rigidbody rigidBody;

    public Vector3 endForce;        // the force to apply in the update!
    private Vector3 initalForce;    // initial push to apply an orbiting behavior

    
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        Gravity.gravitationalObjects.Add(this);
    }

    public void AddEndForce()
    {
        if(endForce != Vector3.zero)
        {
            rigidBody.AddForce(endForce);
            endForce = Vector3.zero;
        }
    }
}
