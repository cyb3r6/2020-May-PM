﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandTeleporation : MonoBehaviour
{
    [Tooltip("This is the transform we want to teleport!")]
    public Transform simHand;

    private LineRenderer teleportLine;
    private bool shouldTeleport;
    private Vector3 hitPosition;
    private SimHandGrab simHandController;

    
    void Start()
    {
        simHandController = GetComponent<SimHandGrab>();
        teleportLine = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        if (simHandController)
        {
            if (simHandController.isTPressed)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, simHandController.transform.forward, out hit))
                {
                    // Do the teleporting!
                    hitPosition = hit.point;
                    teleportLine.SetPosition(0, simHandController.transform.position);
                    teleportLine.SetPosition(1, hitPosition);
                    teleportLine.enabled = true;
                    shouldTeleport = true;
                }
            }
            else if(simHandController.isTPressed == false)
            {
                if(shouldTeleport == true)
                {
                    simHand.transform.position = hitPosition;
                    shouldTeleport = false;
                    teleportLine.enabled = false;
                }
            }
        }
    }
}
