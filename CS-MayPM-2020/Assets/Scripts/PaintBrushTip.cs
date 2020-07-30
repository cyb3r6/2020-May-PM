using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrushTip : MonoBehaviour
{
    public Material paint;
    public bool isTouchingCanvas;
    public Transform canvasTransform;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Paint")
        {
            paint = other.GetComponent<Renderer>().material;
            this.GetComponent<Renderer>().material = paint;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Paintable")
        {
            isTouchingCanvas = true;
            canvasTransform = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Paintable")
        {
            isTouchingCanvas = false;
        }
    }
}
