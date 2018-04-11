using System.Collections.Generic;
using UnityEngine;

public class TestData : MonoBehaviour
{
  public List<Todo> todos = new List<Todo>();

  void Awake()
  {
    todos.Add(new Todo(
      "GET TODOs",
      "Fetch the current TODOs \nfrom the back-end",
      TodoStatus.Planned
    ));
    todos.Add(new Todo(
      "POST TODOs",
      "Post a TODO to the back-\nend",
      TodoStatus.Planned
    ));
    todos.Add(new Todo(
      "Create markup for login",
      "Create a component for the \npage and add a view",
      TodoStatus.Doing
    ));
    todos.Add(new Todo(
      "Create a TODO component",
      "Add a component, a view \nand bindings",
      TodoStatus.Doing
    ));
    todos.Add(new Todo(
      "Style login",
      "Some scss for the login",
      TodoStatus.Done
    ));
    todos.Add(new Todo(
      "NodeJS server",
      "Get the REST endpoint up \n and running",
      TodoStatus.Done
    ));
    todos.Add(new Todo(
      "Document REST endpoint",
      "Make sure those front-\nenders can do their \njobs",
      TodoStatus.Done
    ));
  }
}