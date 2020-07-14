using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintbrush : GrabbableObjectSimHand
{
    public GameObject paintPrefab;
    private PaintBrushTip paintBrushTip;
    private GameObject spawnedPaintLine;
    
    void Start()
    {
        paintBrushTip = GetComponentInChildren<PaintBrushTip>();
    }

    
    void Update()
    {
        if (isBeingHeld)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))// && paintBrushTip.isTouchingCanvas == true)
            {
                Interaction();
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
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
