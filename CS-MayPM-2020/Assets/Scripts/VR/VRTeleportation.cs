using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleportation : MonoBehaviour
{
    [Tooltip("This is the transform we want to teleport!")]
    public Transform vrRig;

    private LineRenderer teleportLine;
    private bool shouldTeleport;
    private Vector3 hitPosition;
    private VRInput controller;

    
    void Start()
    {
        teleportLine = GetComponent<LineRenderer>();
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        if (controller)
        {
            if (controller.isThumbstickPressed)
            {
                RaycastHit hit;
                if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
                {
                    // Do the teleporting!
                    hitPosition = hit.point;
                    teleportLine.SetPosition(0, controller.transform.position);
                    teleportLine.SetPosition(1, hitPosition);
                    teleportLine.enabled = true;
                    shouldTeleport = true;
                }
            }
            else if (controller.isThumbstickPressed == false)
            {
                if (shouldTeleport == true)
                {
                    vrRig.transform.position = hitPosition;
                    shouldTeleport = false;
                    teleportLine.enabled = false;
                }
            }
        }
    }
}
