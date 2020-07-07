using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPaintball : GrabbableObjectSimHand
{
    public GameObject paintballPelletPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounterScript;
    //private GrabbableObjectSimHand grabbableObjectSimHand;

    //private void Awake()
    //{
    //    grabbableObjectSimHand = GetComponent<GrabbableObjectSimHand>();
    //}

    void Update()
    {
        if (isBeingHeld)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interaction();
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
