using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRlocomotion : MonoBehaviour
{
    [Tooltip("This is the transform we want to move!")]
    public Transform vrRig;

    [Tooltip("This is the transform that dictates the player forward direction (head or controller)")]
    public Transform dictator;

    private VRInput controller;
    private Vector3 playerForward;
    private Vector3 playerRight;
    
    void Start()
    {
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        playerForward = dictator.forward;
        playerForward.y = 0;
        playerForward.Normalize();

        playerRight = dictator.right;
        playerRight.y = 0f;
        playerRight.Normalize();

        vrRig.Translate(playerForward * controller.thumbstick.y * Time.deltaTime);
        vrRig.Translate(playerRight * controller.thumbstick.x * Time.deltaTime);
    }
}
