using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject objectToPlace;

    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Vector2 touchPosition;

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    // if we have touched our screen and where
    bool TryGetTouchPosition(out Vector2 touchPosition)  // = either true or false
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;

            return true;
        }

        touchPosition = default;    // a default value for a Vector2 (0,0)

        return false;
    }

    
    void Update()
    {
        // first have to detect if we've touched the screen
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if(arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            GameObject spawnedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
        }
    }
}
