using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class ThrowArticle : MonoBehaviour
{
  public GameObject articlePrefab;
  public float initialSpeed = 100.0f;

  private ThrownArticlesState thrownArticles;

  void Start()
  {
    thrownArticles = GameObject.FindObjectOfType<ThrownArticlesState>();
  }

  void Update()
  {
    if (Input.touchCount > 0)
    {
      var touch = Input.GetTouch(0);
      if (touch.phase == TouchPhase.Began)
      {
        var cameraIsLookingAt = Camera.main.transform.forward;
        var positionOfScreenToWorld = Camera.main.ScreenToWorldPoint(touch.position);

        thrownArticles.ThrowArticle(articlePrefab, positionOfScreenToWorld, cameraIsLookingAt, initialSpeed);
      }
    }
  }



}
