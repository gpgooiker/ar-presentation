using System.Collections;
using UnityEngine;

/// <summary>
/// A navigation bar is a collection of buttons that is easily discovered by the user. Wherever the user
/// moves to, the navigation bar will be visible if the user looks to the floor.
/// </summary>

public class NavigationBarState : MonoBehaviour
{
  public GameObject navigationInOverlay;
  public bool isPressed;

  private RectTransform navigationTransform;

  void Start()
  {
    isPressed = false;

    if (GameObject.FindObjectsOfType(this.GetType()).Length > 1)
    {
      Debug.LogWarning("There are several game objects with " + this.GetType() + " attached. Make sure there's only one.");
    }

    if (navigationInOverlay == null)
    {
      Debug.LogWarning("Attach a 'navigation bar' UI element to NavigationBarState");
    }

    navigationTransform = navigationInOverlay.GetComponent<RectTransform>();
  }

  void Update()
  {
    Vector3 position = new Vector3(navigationTransform.position.x, navigationTransform.position.y, navigationTransform.position.z);

    if (lookingDown())
    {
      Vector3 show = new Vector3(position.x, 90f, position.z);
      navigationTransform.position = show;
    }
    else
    {
      Vector3 hide = new Vector3(position.x, -90f, position.z);
      navigationTransform.position = hide;
    }
  }

  public void pressBar()
  {
    isPressed = true;
    StartCoroutine(UnpressBar());
  }

  private bool lookingDown()
  {
    return Vector3.Angle(Camera.main.transform.forward, Vector3.down) < 20;
  }


  IEnumerator UnpressBar()
  {
    yield return new WaitForSeconds(1);
    this.isPressed = false;
  }
}
