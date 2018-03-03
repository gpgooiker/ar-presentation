using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ARAnchorFeedback : MonoBehaviour {
  private Text feedback;
  private ARAnchorsState anchors;

  void Start () {
    feedback = GetComponent<Text>();
    anchors = GameObject.FindObjectOfType<ARAnchorsState>();
  }

	void Update () {
    feedback.text = "Number of anchors: " + anchors.GetCurrentPlaneAnchors().Count.ToString();
  }
}
