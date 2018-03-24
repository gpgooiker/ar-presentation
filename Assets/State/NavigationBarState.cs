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
    Vector3 cameraPosition = Camera.main.transform.position;
    float justUnderCamera = cameraPosition.y - (float)0.4;
    Vector3 navBarPosition = new Vector3(cameraPosition.x, justUnderCamera, cameraPosition.z);

    Vector3 navBarForwardOnHorizontal = Vector3.ProjectOnPlane(navigationBar.transform.forward, Vector3.up);
    Vector3 cameraForwardOnHorizontal = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);

    Quaternion rotateToWhereCameraLooks = new Quaternion();
    rotateToWhereCameraLooks.SetLookRotation(cameraForwardOnHorizontal, Vector3.up);

    navigationBar.transform.SetPositionAndRotation(navBarPosition, rotateToWhereCameraLooks);
  }
}
