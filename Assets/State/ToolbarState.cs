using System.Collections;
using UnityEngine;

/// <summary>
/// A toolbar is a collection of buttons that is easily discovered by the user. Wherever the user
/// moves to, the toolbar will be visible if the user looks to the floor.
/// </summary>

public class ToolbarState : MonoBehaviour
{
  public GameObject toolbar;
  public bool isPressed;

  private RectTransform barTransform;
  private float toolbarHeight = 100;
  private float toolbarPadding = 25f;
  private float angleToDownDirection = 0f;

  void Start()
  {
    isPressed = false;

    if (GameObject.FindObjectsOfType(this.GetType()).Length > 1)
    {
      Debug.LogWarning("There are several game objects with " + this.GetType() + " attached. Make sure there's only one.");
    }

    if (toolbar == null)
    {
      Debug.LogWarning("Attach a 'Toolbar' UI element to ToolbarState");
    }

    barTransform = toolbar.GetComponent<RectTransform>();
    toolbarHeight = barTransform.sizeDelta.y;
  }

  void Update()
  {
    Vector3 position = new Vector3(barTransform.position.x, barTransform.position.y, barTransform.position.z);
    angleToDownDirection = Vector3.Angle(Camera.main.transform.forward, Vector3.down);

    if (lookingDown())
    {
      Vector3 show = new Vector3(position.x, toolbarHeight / 2, position.z);
      barTransform.position = show;
    }
    else
    {
      Vector3 hide = new Vector3(position.x, -1 * toolbarPadding, position.z);
      barTransform.position = hide;
    }
  }

  public void pressButton()
  {
    isPressed = true;
    StartCoroutine(UnpressBar());
  }

  public bool StartingToLookDown()
  {
    Debug.Log(angleToDownDirection);
    return angleToDownDirection < 50f && angleToDownDirection > 20f;
  }

  public bool lookingDown()
  {
    return angleToDownDirection < 20f;
  }

  IEnumerator UnpressBar()
  {
    yield return new WaitForSeconds(2);
    this.isPressed = false;
  }
}
