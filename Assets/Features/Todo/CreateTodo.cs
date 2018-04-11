using UnityEngine;

public enum TodoStatus
{
  Planned, Doing, Reviewing, Done
}

public struct Todo
{
  public string title, body;
  public TodoStatus status;

  public Todo(string t, string b, TodoStatus s)
  {
    title = t;
    body = b;
    status = s;
  }
}

public class CreateTodo : MonoBehaviour
{

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
