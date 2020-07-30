using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintbrushVR : GrabbableObjectVR
{
    public GameObject paintPrefab;
    private PaintBrushTip paintBrushTip;
    private GameObject spawnedPaintLine;
    private bool enable;

    void Start()
    {
        paintBrushTip = GetComponentInChildren<PaintBrushTip>();
    }
    
    void Update()
    {
        if (isBeingHeld)
        {
            if (controller.triggerValue > 0.8f && !enable)
            {
                enable = true;

                if(paintBrushTip.isTouchingCanvas == true)
                {
                    Interaction();
                }                
            }
            else if (controller.triggerValue < 0.8f && enable)
            {
                enable = false;

                spawnedPaintLine.transform.position = spawnedPaintLine.transform.position;
                spawnedPaintLine = null;
            }

            if (spawnedPaintLine)
            {
                spawnedPaintLine.transform.position = new Vector3(paintBrushTip.transform.position.x, paintBrushTip.transform.position.y, paintBrushTip.canvasTransform.position.z);
            }
        }
    }

    private void Interaction()
    {
        spawnedPaintLine = Instantiate(paintPrefab, paintBrushTip.gameObject.transform.position, paintBrushTip.gameObject.transform.rotation);
        TrailRenderer paintTrail = spawnedPaintLine.GetComponent<TrailRenderer>();
        paintTrail.GetComponent<Renderer>().material = paintBrushTip.paint;

    }
}
