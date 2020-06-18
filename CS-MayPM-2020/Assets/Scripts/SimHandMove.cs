using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandMove : MonoBehaviour
{
    public Vector3 location;
    public Transform otherLocation;
    public float moveSpeed;
    public float turnSpeed;
    public float jumpForce;
    private Rigidbody peterRigidbody;
        
    void Start()
    {
        //transform.position = location;
        peterRigidbody = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        #region Translational movement
        // move forward using W
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        // move back using S
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }

        // move right using D
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        // move left using A
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }

        // move up
        if (Input.GetKey(KeyCode.Space))
        {
            //transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            peterRigidbody.AddForce(Vector3.up * jumpForce);
        }

        // move down
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }

        // sprint?!
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = moveSpeed * 5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = moveSpeed / 5f;
        }

        #endregion

        #region Rotation using Keyboard
        
        // Rotation
        // rotate left
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down* Time.deltaTime * turnSpeed, Space.World);
        }

        // rotate right
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed, Space.World);
        }

        // rotate forward
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed, Space.World);
        }

        // rotate backward
        if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed, Space.World);
        }
        
        #endregion

        #region Rotate using Mouse
        /*
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnSpeed, Space.World);
        transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * turnSpeed, Space.Self);
        */
        #endregion
    }

    
}
