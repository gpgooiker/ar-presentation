using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class ProjectionScreenState : MonoBehaviour
{
  public GameObject informationPrefab;
  public GameObject informationPreviewPrefab;
  private GameObject preview;
  private bool placingInformation = false;
  private List<GameObject> itemsOfInformation = new List<GameObject>();

  void Start()
  {
    if (GameObject.FindObjectsOfType(this.GetType()).Length > 1)
    {
      Debug.LogWarning("There are several game objects with " + this.GetType() + " attached. Make sure there's only one.");
    }
  }

  void Update()
  {
    if (placingInformation)
    {
      Ray projectingRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
      RaycastHit projectingHit;

      if (Physics.Raycast(projectingRay, out projectingHit))
      {
        if (projectingHit.transform.gameObject.name == "Projection screen")
        {
          if (preview == null)
          {
            preview = Instantiate(informationPreviewPrefab, projectingHit.point, Quaternion.identity);
          }
          else
          {
            preview.transform.position = projectingHit.point;

            if (Input.touchCount > 0)
            {
              GameObject pieceOfInformation = Instantiate(informationPrefab, projectingHit.point, Quaternion.identity);
              itemsOfInformation.Add(pieceOfInformation);
              placingInformation = false;
              preview = null;
            }
          }
        }
      }
    }

  }

  public void PlaceInformation()
  {
    placingInformation = true;
  }
}
