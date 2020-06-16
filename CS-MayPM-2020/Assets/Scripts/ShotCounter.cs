using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCounter : MonoBehaviour
{
    public Text shotCounterText;
    public int shotsFired;

    void Update()
    {
        shotCounterText.text = "Shots Fired: " + shotsFired;
    }
}
