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

    public delegate void ButtonPressedEvent();  // subscribing methods to this variable
    public ButtonPressedEvent OnButtonPressed;  // instance of the delegate

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonAnim.SetTrigger("Pressed");

            // Do something!
            buttonPressedEvent?.Invoke();

            // run any methods that are subscribed to the ButtonPressedEvent delegate
            OnButtonPressed();

            videoPlane.SetActive(!videoPlane.activeInHierarchy);
        }
    }
}
