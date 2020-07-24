using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WreckingCanvas : MonoBehaviour
{
    public Text text;

    private void Update()
    {
        text.text = "You've killed: " + GameManager.instance.numberOfCubesDestroyed.ToString() + " cubes";
    }

}
