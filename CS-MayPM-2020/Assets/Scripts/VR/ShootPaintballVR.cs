using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPaintballVR : MonoBehaviour
{
    public GameObject paintballPelletPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounterScript;
    private GrabbableObjectVR grabbableObjectVR;

    private bool enable;

    void Start()
    {
        grabbableObjectVR = GetComponent<GrabbableObjectVR>();
    }

    
    void Update()
    {
        if (grabbableObjectVR.isBeingHeld)
        {
            if (grabbableObjectVR.controller.triggerValue > 0.8f && !enable)
            {
                enable = true;
                Interaction();
            }
            else if(grabbableObjectVR.controller.triggerValue < 0.8f && enable)
            {
                enable = false;
            }
        }
    }

    public void Interaction()
    {
        GameObject temp = Instantiate(paintballPelletPrefab, spawnPoint.position, spawnPoint.rotation);
        temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward * shootingForce);
        shotCounterScript.shotsFired++;
        Destroy(temp, 3);
    }
}
