using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Rigidbody leverRigidbody;
    public HingeJoint myJoint;
    public Vector3 centerOfMass = Vector3.zero;        // to override the COM of the joint;

    
    void Start()
    {
        leverRigidbody = GetComponent<Rigidbody>();
        leverRigidbody.centerOfMass = centerOfMass;
    }

    // calculate and return a number between -1 and 1
    // if the lever is in the middle, it'll return a 0;
    public float NormalizedJointAngle()
    {
        float normalizedAngle = myJoint.angle / myJoint.limits.max;
        return normalizedAngle;
    }
}
