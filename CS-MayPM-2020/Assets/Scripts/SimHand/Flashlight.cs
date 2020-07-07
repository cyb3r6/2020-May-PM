using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : GrabbableObjectSimHand
{
    private Light flashlight;
    
    void Start()
    {
        flashlight = GetComponentInChildren<Light>();
    }

    
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
        flashlight.enabled = !flashlight.enabled;
    }
}
