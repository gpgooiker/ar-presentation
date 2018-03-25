using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

/// <summary>
/// A navigation bar is a collection of buttons that is easily discovered by the user. Wherever the user
/// moves to, the navigation bar will be visible if the user looks to the floor.
///
/// Attach this class as a component to an empty game object in Unity. Then, create a navigation bar
/// game object in Unity and link it to the empty game object.
/// </summary>

public class NavigationBarState : MonoBehaviour
{
  public GameObject navigationBar;
  public float distanceUnderCamera = 0.4f;

  void Start()
  {
    if (GameObject.FindObjectsOfType<NavigationBarState>().Length > 1)
    {
      Debug.LogWarning("There are several game objects with NavigationBarState attached. Make sure there's only one.");
    }

    if (navigationBar == null)
    {
      Debug.LogWarning("Attach a navigation bar game object to NavigationBarState");
    }
  }

  void LateUpdate()
  {
    Debug.Log(!lookingDown());
    if (!lookingDown())
    {
      Transform cameraTransform = Camera.main.transform;

      navigationBar.transform.SetPositionAndRotation(placeBelow(cameraTransform.position), rotateAroundYAxisTo(cameraTransform.forward));
    }
  }

  private bool lookingDown()
  {
    Debug.Log(Vector3.Angle(Camera.main.transform.forward, Vector3.down));
    return Vector3.Angle(Camera.main.transform.forward, Vector3.down) < 20;
  }

  private Vector3 placeBelow(Vector3 position)
  {
    return new Vector3
    (
      position.x,
      position.y - distanceUnderCamera,
      position.z
    );
  }

  private Quaternion rotateAroundYAxisTo(Vector3 lookTo)
  {
    Vector3 lookToOnHorizontalPlane = Vector3.ProjectOnPlane(lookTo, Vector3.up);

    Quaternion rotateAroundYAxis = new Quaternion();
    rotateAroundYAxis.SetLookRotation(lookToOnHorizontalPlane, Vector3.up);

    return rotateAroundYAxis;
  }
}
