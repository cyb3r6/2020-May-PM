﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPaintball : MonoBehaviour
{
    public GameObject paintballPelletPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounterScript;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject temp = Instantiate(paintballPelletPrefab, spawnPoint.position, spawnPoint.rotation);
            temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward * shootingForce);
            shotCounterScript.shotsFired++;
            Destroy(temp, 3);
        }
    }
}
