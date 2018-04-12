using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Toolbar : MonoBehaviour
{
  public GameObject toolbarHint;

  private ToolbarState toolbarState;
  private ProjectionScreenState projectionScreenState;
  private Button addButton;
  private Text buttonText;
  private GraphicRaycaster canvasRaycaster;
  private PointerEventData pointer;
  private EventSystem events;
  private Color interactionColor;
  private Color activeColor;

  void Start()
  {
    toolbarState = GameObject.FindObjectOfType<ToolbarState>();
    projectionScreenState = GameObject.FindObjectOfType<ProjectionScreenState>();

    addButton = gameObject.GetComponentInChildren<Button>();
    buttonText = addButton.GetComponentInChildren<Text>();
    canvasRaycaster = gameObject.GetComponentInParent<GraphicRaycaster>();
    events = gameObject.GetComponentInParent<EventSystem>();

    interactionColor = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b);
    activeColor = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, 0.6f);
    buttonText.text = "New Todo";
  }

  void Update()
  {
    if (toolbarState.isPressed)
    {
      buttonText.color = activeColor;
    }
    else
    {
      buttonText.color = interactionColor;
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
          if (result.gameObject.name == "PlaceTodoButton")
          {
            toolbarState.pressButton();
            projectionScreenState.PlaceInformation();
          }
        }
      }
    }

    if (toolbarHint != null)
    {
      toolbarHint.SetActive(toolbarState.StartingToLookDown());
    }
  }
}