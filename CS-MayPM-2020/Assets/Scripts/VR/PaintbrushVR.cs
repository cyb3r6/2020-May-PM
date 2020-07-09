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
                Interaction();
            }
            else if (controller.triggerValue < 0.8f && enable)
            {
                enable = false;

                spawnedPaintLine.transform.position = spawnedPaintLine.transform.position;
                spawnedPaintLine = null;
            }

            if (spawnedPaintLine)
            {
                spawnedPaintLine.transform.position = paintBrushTip.transform.position;
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
