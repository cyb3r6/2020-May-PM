using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandMove : MonoBehaviour
{
    public Vector3 location;
    public Transform otherLocation;
    public float moveSpeed;
        
    void Start()
    {
        //transform.position = location;
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        // move back using S

        // move right using D

        // move left using A
    }
}
