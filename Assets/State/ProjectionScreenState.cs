﻿using System.Collections.Generic;
using UnityEngine;

public class ProjectionScreenState : MonoBehaviour
{
  public GameObject ticketPrefab;
  public GameObject ticketPreviewPrefab;
  private GameObject preview;
  private bool placingInformation;
  private List<GameObject> tickets = new List<GameObject>();

  void Start()
  {
    placingInformation = false;

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
            preview = Instantiate(ticketPreviewPrefab, projectingHit.point, Quaternion.identity);
          }
          else
          {
            preview.transform.position = projectingHit.point;
          }
        }
      }
    }

    if (preview != null && Input.anyKey)
    {
      GameObject newTicket = Instantiate(ticketPrefab, preview.transform.position, Quaternion.identity);
      TicketBehavior newTicketBehavior = newTicket.GetComponent<TicketBehavior>();
      newTicketBehavior.SetTicketContent(tickets.Count);
      tickets.Add(newTicket);
      placingInformation = false;
      Object.Destroy(preview);
      preview = null;
    }
  }

  public void PlaceInformation()
  {
    placingInformation = true;
  }
}
