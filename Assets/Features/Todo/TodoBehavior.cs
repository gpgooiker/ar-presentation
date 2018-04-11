using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(TestData))]
public class TodoBehavior : MonoBehaviour
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

    if (testData.todos.Count > 0)
    {
      int timesLarger = (int)Mathf.Floor(index / testData.todos.Count);
      int clampedIndex = index - timesLarger * testData.todos.Count;

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

      titleTextMesh.text = testData.todos[clampedIndex].title;
      bodyTextMesh.text = testData.todos[clampedIndex].body;
      statusTextMesh.text = testData.todos[clampedIndex].status.ToString();
    }
  }
}
