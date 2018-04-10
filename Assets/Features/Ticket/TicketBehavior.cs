using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(TestData))]
public class TicketBehavior : MonoBehaviour
{
  public GameObject TitleGameObject;
  public GameObject BodyGameObject;
  public GameObject StatusGameObject;
  private TestData testData;
  private TextMesh titleTextMesh;
  private TextMesh bodyTextMesh;
  private TextMesh statusTextMesh;

  public void SetTicketContent(int index)
  {
    testData = GetComponent<TestData>();

    if (testData.ticketsData.Count > 0)
    {
      int timesLarger = (int)Mathf.Floor(index / testData.ticketsData.Count);
      int clampedIndex = index - timesLarger * testData.ticketsData.Count;

      if (TitleGameObject != null)
      {
        titleTextMesh = TitleGameObject.GetComponent<TextMesh>();
      }

      if (BodyGameObject != null)
      {
        bodyTextMesh = BodyGameObject.GetComponent<TextMesh>();
      }

      if (StatusGameObject != null)
      {
        statusTextMesh = StatusGameObject.GetComponent<TextMesh>();
      }

      titleTextMesh.text = testData.ticketsData[clampedIndex].title;
      bodyTextMesh.text = testData.ticketsData[clampedIndex].body;
      statusTextMesh.text = testData.ticketsData[clampedIndex].status.ToString();
    }
  }
}
