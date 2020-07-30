using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingCube : MonoBehaviour
{
    public AnimatedButton resetButton;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody cubeRigidBody;

    private AudioSource audio;
    
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        cubeRigidBody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

        // start listening to OnButtonPressed()
        resetButton.OnButtonPressed += ResetCubes;
    }

    public void ResetCubes()
    {
        // reset position and rotation
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;

        // turn on cube renderer
        GetComponent<Renderer>().enabled = true;

        // stop the cubes inertia
        cubeRigidBody.velocity = Vector3.zero;
        cubeRigidBody.angularVelocity = Vector3.zero;

        // reset the score!
        GameManager.instance.numberOfCubesDestroyed = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 5)
        {
            audio.Play();
        }
    }
}
