using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wreckit : MonoBehaviour
{
    public Lever forwardBackwardController, leftRightController;
    public float speed;    
    
    void Update()
    {
        // move forward and backward
        transform.position = transform.position + transform.forward * forwardBackwardController.NormalizedJointAngle() * Time.deltaTime * speed;

        // move left and right
        transform.position = transform.position + transform.right * leftRightController.NormalizedJointAngle() * Time.deltaTime * speed;


    }
}
