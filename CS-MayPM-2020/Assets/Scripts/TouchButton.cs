using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    public Transform button, down;
    public AudioSource audioSource;

    // Simplify this script!
    private Vector3 originalPosition;
    
    void Start()
    {
        originalPosition = button.position;     // saving the original position of the button (the up position!)
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            button.position = down.position;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            button.position = originalPosition;
        }
    }
}
