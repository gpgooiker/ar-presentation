using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ARAnchorFeedback : MonoBehaviour
{
  private Text feedback;
  private ARAnchorsState anchorsState;

  void Start()
  {
    feedback = GetComponent<Text>();
    anchorsState = GameObject.FindObjectOfType<ARAnchorsState>();
  }

  void Update()
  {
    feedback.text = "";

    if (anchorsState.GetCurrentPlaneAnchors() != null)
    {
      feedback.text += "Anchors: " + anchorsState.GetCurrentPlaneAnchors().Count.ToString() + " - ";
    }

    feedback.text += "Cam: " + Camera.main.transform.position.ToString();
  }
}
