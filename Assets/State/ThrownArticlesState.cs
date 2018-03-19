using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class ThrownArticlesState : MonoBehaviour
{
  private List<GameObject> thrownArticles = new List<GameObject>();

  void Start()
  {
    if (GameObject.FindObjectsOfType<ThrownArticlesState>().Length > 1)
    {
      Debug.LogWarning("There are several game objects with ThrownArticlesState attached. Make sure there's only one.");
    }
  }

  public void ThrowArticle(GameObject article, Vector3 startingPoint, Vector3 direction, float initialSpeed)
  {
    GameObject articleGameObject = Instantiate(article, startingPoint, Quaternion.identity);
    Rigidbody articleBody = articleGameObject.GetComponent<Rigidbody>();

    if (articleBody)
    {
      articleBody.AddForce(direction * initialSpeed, ForceMode.Force);
      Debug.Log(direction * initialSpeed);

    }
    thrownArticles.Add(articleGameObject);
  }

  public List<GameObject> GetThrownArticles()
  {
    return thrownArticles;
  }
}
