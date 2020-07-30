using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public static List<GravitationalObject> gravitationalObjects = new List<GravitationalObject>();

    [Range(-10, 20)]
    public float gravitationalForce = 1f;
    
    void FixedUpdate()
    {
        int loopCount = 1;

        foreach(GravitationalObject gravityObject in gravitationalObjects)
        {
            for(int i = loopCount; i < gravitationalObjects.Count; i++)
            {
                Rigidbody objectGravityRigidBody = gravityObject.rigidBody;
                CalculateGravity(gravityObject, gravitationalObjects[i], objectGravityRigidBody, gravitationalObjects[i].rigidBody);
            }
            loopCount++;
        }
        AddGravitationalForce();
    }

    private void CalculateGravity(GravitationalObject object1, GravitationalObject object2, Rigidbody m1, Rigidbody m2)
    {
        Vector3 r = m1.position - m2.position;

        if(r == Vector3.zero)
        {
            return;
        }

        Vector3 force = r.normalized * (gravitationalForce * m1.mass * m2.mass / Mathf.Pow(r.magnitude, 2));

        object1.endForce -= force;
        object2.endForce += force;

    }

    private void AddGravitationalForce()
    {
        foreach(GravitationalObject gObject in gravitationalObjects)
        {
            gObject.AddEndForce();
        }
    }
}
