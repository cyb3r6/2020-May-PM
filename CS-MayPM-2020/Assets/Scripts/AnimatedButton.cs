using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatedButton : MonoBehaviour
{
    public Animator buttonAnim;

    // using a public Unity Event!
    public UnityEvent buttonPressedEvent;

    public GameObject videoPlane;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonAnim.SetTrigger("Pressed");

            // Do something!
            buttonPressedEvent?.Invoke();

            videoPlane.SetActive(!videoPlane.activeInHierarchy);
        }
    }
}
