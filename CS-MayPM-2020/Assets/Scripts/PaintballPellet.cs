using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballPellet : MonoBehaviour
{
    private Material paintMaterial;
    public List<Material> paintballMaterials = new List<Material>();
    static private int paintIndex = 0;
    
    void Start()
    {
        paintMaterial = GetComponentInChildren<Renderer>().material;
    }

    private void OnCollisionEnter(Collision theThingThatWeCollidedWith)
    {
        if(theThingThatWeCollidedWith.collider.tag == "Paintable")
        {
            theThingThatWeCollidedWith.collider.GetComponent<Renderer>().material = paintballMaterials[paintIndex];
            paintIndex++;

            if(paintIndex == paintballMaterials.Count)
            {
                paintIndex = 0;
            }
        }
    }
}
