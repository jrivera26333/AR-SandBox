using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    /// <summary>
    /// We are grabbing the Script attached to the gameobject and accessing the data.
    /// </summary>
    [SerializeField] IsSelected[] spheresToOptions;
    Color inActiveColor = Color.white;
    Color activeColor = Color.black;

    Vector2 touchPosition;

    void SpherePointer()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                var orbHit = hit.transform.GetComponent<IsSelected>();
                if(orbHit != null)
                {
                    ToggleColors(orbHit);
                }
            }
        }
    }

    void OtherSolution()
    {
        if(Input.touchCount > 0)
        {
            //Grabs the struct which defines the first touch
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position; //Grabs the touch position

            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    var orbHit = hit.transform.GetComponent<IsSelected>();
                    if (orbHit != null)
                    {
                        ToggleColors(orbHit);
                    }
                }
            }
        }
    }

    void ToggleColors(IsSelected objectHit)
    {
        //By accessing the data we have a hand on the object
        foreach(IsSelected sphere in spheresToOptions)
        {
            MeshRenderer meshRenderer = sphere.GetComponent<MeshRenderer>();
            //Polymorphism
            if(objectHit != sphere)
            {
                sphere.amIselected = false;
                meshRenderer.material.color = inActiveColor;
            }
            else
            {
                sphere.amIselected = true;
                meshRenderer.material.color = activeColor;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpherePointer();
    }
}
