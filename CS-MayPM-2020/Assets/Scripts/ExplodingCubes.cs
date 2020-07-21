using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingCubes : MonoBehaviour
{
    private List<Rigidbody> cubeRigidbodies = new List<Rigidbody>();
    
    void Start()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            cubeRigidbodies.Add(this.transform.GetChild(i).GetComponent<Rigidbody>());
            Debug.Log("the cube is: " + cubeRigidbodies[i].gameObject.name);
        }
    }
    public void ExplodeCubes()
    {
        // apply explosion force to the cubes!
    }
}
