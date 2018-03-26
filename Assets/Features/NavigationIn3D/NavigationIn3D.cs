using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationIn3D : MonoBehaviour
{
  public Material pressedMaterial;
  private Material defaultMaterial;
  private NavigationBarState navigationBarState;
  private ProjectionScreenState projectionScreenState;

  void Start()
  {
    navigationBarState = GameObject.FindObjectOfType<NavigationBarState>();
    projectionScreenState = GameObject.FindObjectOfType<ProjectionScreenState>();
    defaultMaterial = GetComponent<Renderer>().material;
  }

  void Update()
  {
    if (Input.touchCount > 0)
    {
      var touch = Input.GetTouch(0);
      if (touch.phase == TouchPhase.Began)
      {
        Ray touchRay = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit touchHit;

        if (Physics.Raycast(touchRay, out touchHit))
        {

          if (touchHit.transform.gameObject.name == "Navigation bar")
          {
            navigationBarState.pressBar();
            projectionScreenState.PlaceInformation();
          }
        }
      }
    }

    if (navigationBarState.isPressed)
    {
      GetComponent<Renderer>().material = pressedMaterial;
    }
    else
    {
      GetComponent<Renderer>().material = defaultMaterial;
    }
  }
}
