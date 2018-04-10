using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

///<summary>
/// Expose the ARPlaneAnchors that are currently detected by ARKit.
///</summary>

public sealed class ARAnchorsState : MonoBehaviour
{
  public GameObject planePrefab;
  private UnityARAnchorManager unityARAnchorManager;

  void Start()
  {
    unityARAnchorManager = new UnityARAnchorManager();
    UnityARUtility.InitializePlanePrefab(planePrefab);

    if (GameObject.FindObjectsOfType(this.GetType()).Length > 1)
    {
      Debug.LogWarning("There are several game objects with " + this.GetType() + " attached. Make sure there's only one.");
    }
  }

  void OnDestroy()
  {
    unityARAnchorManager.Destroy();
  }

  public ICollection<ARPlaneAnchorGameObject> GetCurrentPlaneAnchors()
  {
    return unityARAnchorManager.GetCurrentPlaneAnchors();
  }
}