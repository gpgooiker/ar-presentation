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
  }

  void Update()
  {
    Vector3 position = new Vector3(barTransform.position.x, barTransform.position.y, barTransform.position.z);

    if (lookingDown())
    {
      Vector3 show = new Vector3(position.x, 40f, position.z);
      barTransform.position = show;
    }
    else
    {
      Vector3 hide = new Vector3(position.x, -25f, position.z);
      barTransform.position = hide;
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
