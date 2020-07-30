using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wreckit : MonoBehaviour
{
    public Lever forwardBackwardController, leftRightController, rotationController;
    public float speed;    
    
    void Update()
    {
        // move forward and backward. added deadzones (0.05f)
        if(Mathf.Abs(forwardBackwardController.NormalizedJointAngle()) > 0.05f)
        {
            transform.position = transform.position + transform.forward * forwardBackwardController.NormalizedJointAngle() * Time.deltaTime * speed;
        }


        // move left and right. added deadzone!
        if (Mathf.Abs(leftRightController.NormalizedJointAngle()) > 0.05f)
        {
            transform.position = transform.position + transform.right * leftRightController.NormalizedJointAngle() * Time.deltaTime * speed;
        }

        if (Mathf.Abs(rotationController.NormalizedJointAngle()) > 0.05f)
        {
            transform.Rotate(Vector3.up, rotationController.NormalizedJointAngle() * Time.deltaTime * speed);
        }

    }
}
