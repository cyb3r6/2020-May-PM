using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandAnimator : MonoBehaviour
{
    private Animator vrHandAnimator;
    private VRInput vrInputController;

    void Awake()
    {
        vrHandAnimator = GetComponentInChildren<Animator>();
        vrInputController = GetComponent<VRInput>();
    }

    void Update()
    {
        if(vrInputController && vrHandAnimator)
        {
            vrHandAnimator.Play("Fist Closing", 0, vrInputController.gripValue);
        }
    }
}
