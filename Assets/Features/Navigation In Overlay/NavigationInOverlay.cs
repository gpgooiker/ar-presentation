using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NavigationInOverlay : MonoBehaviour
{
  private NavigationBarState navigationBarState;
  private ProjectionScreenState projectionScreenState;
  private Button addButton;
  private Text buttonText;
  private GraphicRaycaster canvasRaycaster;
  private PointerEventData pointer;
  private EventSystem events;

  void Start()
  {
    navigationBarState = GameObject.FindObjectOfType<NavigationBarState>();
    projectionScreenState = GameObject.FindObjectOfType<ProjectionScreenState>();
    addButton = gameObject.GetComponent<Button>();
    buttonText = addButton.GetComponentInChildren<Text>();
    canvasRaycaster = gameObject.GetComponentInParent<GraphicRaycaster>();
    events = gameObject.GetComponentInParent<EventSystem>();
  }

  void Update()
  {
    if (navigationBarState != null && navigationBarState.isPressed)
    {
      buttonText.text = "Placing a ticket";
    }
    else
    {
      buttonText.text = "Place a ticket";
    }

    if (canvasRaycaster != null && events != null && Input.touchCount > 0)
    {
      var touch = Input.GetTouch(0);
      if (touch.phase == TouchPhase.Began)
      {
        pointer = new PointerEventData(events);
        pointer.position = touch.position;
        List<RaycastResult> results = new List<RaycastResult>();

        canvasRaycaster.Raycast(pointer, results);

        foreach (RaycastResult result in results)
        {
          navigationBarState.pressBar();
          projectionScreenState.PlaceInformation();
        }
      }
    }
  }
}

