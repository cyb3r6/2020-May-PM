using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingCubeZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WreckingCubes")
        {
            GameManager.instance.CountCubesDestroy();
            other.GetComponent<Renderer>().enabled = false;
        }
    }
}
