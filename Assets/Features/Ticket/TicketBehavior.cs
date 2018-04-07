using UnityEngine;

public class TicketBehavior : MonoBehaviour
{
  public TextMesh TitleTextMesh;

  void Start()
  {
  }

  void Update()
  {

  }

  public void SetTitle(string t)
  {
    if (TitleTextMesh != null)
    {
      TitleTextMesh.text = t;
    }
  }
}
