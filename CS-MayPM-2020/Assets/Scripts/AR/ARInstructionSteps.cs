using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInstructionSteps : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject initializeHeatCanvas;
    public GameObject saltWaterCanvas;

    // Add more Canvases/Steps!

    private List<GameObject> steps = new List<GameObject>();
    private int currentStep = 0;
    private GameObject currentCanvas;

    
    public void TurnOnInitializeHeatCanvas()
    {
        initializeHeatCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);

        // makes sure that our list of steps is empty!
        steps.Clear();

        for(int i = 0; i < initializeHeatCanvas.transform.childCount - 2; i++)
        {
            steps.Add(initializeHeatCanvas.transform.GetChild(i).gameObject);
        }
        currentCanvas = initializeHeatCanvas;
    }
    public void TurnOnSaltWaterCanvas()
    {
        saltWaterCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);

        steps.Clear();
        for (int i = 0; i < saltWaterCanvas.transform.childCount - 2; i++)
        {
            steps.Add(saltWaterCanvas.transform.GetChild(i).gameObject);
        }
        currentCanvas = saltWaterCanvas;
    }

    public void NextStep()
    {
        steps[currentStep].SetActive(false);

        Debug.Log("currentStep is: " + currentStep);

        if(currentStep == steps.Count - 1)
        {
            currentStep = 0;
            steps[currentStep].SetActive(true);
            currentCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);

            return;
        }

        steps[++currentStep].SetActive(true);
    }

    // homework!
    public void PreviousStep()
    {
        steps[currentStep].SetActive(false);

        Debug.Log("currentStep is: " + currentStep);

        if (currentStep <= 0)
        {
            currentStep = 0;
            steps[currentStep].SetActive(true);
            currentCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);

            return;
        }

        steps[--currentStep].SetActive(true);
    }
}
