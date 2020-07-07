using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObjectSimHand : MonoBehaviour
{
    public GameObject hand;
    public bool isBeingHeld;
    public SimHandGrab simHandController;
    public Vector3 grabOffset = Vector3.zero;   // (0, 0, 0)
}
