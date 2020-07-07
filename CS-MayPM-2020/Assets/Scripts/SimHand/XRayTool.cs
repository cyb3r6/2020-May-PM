using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayTool : GrabbableObjectSimHand
{
    private bool isXrayed;
    public GameObject xRay;       

    void Update()
    {
        if (isBeingHeld)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interaction();
            }
        }
    }

    private void Interaction()
    {
        isXrayed = !isXrayed;
        if (isXrayed)
        {
            xRay.GetComponent<Renderer>().material.renderQueue = 3002;
        }
        else
        {
            xRay.GetComponent<Renderer>().material.renderQueue = 3001;
        }
    }
}
