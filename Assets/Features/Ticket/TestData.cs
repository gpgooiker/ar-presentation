using System.Collections.Generic;
using UnityEngine;

public class TestData : MonoBehaviour
{
  public List<Ticket> ticketsData = new List<Ticket>();

  void Awake()
  {
    ticketsData.Add(new Ticket(
      "GET TODOs",
      "Fetch the current TODOs \nfrom the back-end",
      TicketStatus.Planned
    ));
    ticketsData.Add(new Ticket(
      "POST TODOs",
      "Post a TODO to the back-\nend",
      TicketStatus.Planned
    ));
    ticketsData.Add(new Ticket(
      "Create markup for login",
      "Create a component for the \npage and add a view",
      TicketStatus.Doing
    ));
    ticketsData.Add(new Ticket(
      "Create a TODO component",
      "Add a component, a view \nand bindings",
      TicketStatus.Doing
    ));
    ticketsData.Add(new Ticket(
      "Style login",
      "Some scss for the login",
      TicketStatus.Done
    ));
    ticketsData.Add(new Ticket(
      "NodeJS server",
      "Get the REST endpoint up \n and running",
      TicketStatus.Done
    ));
    ticketsData.Add(new Ticket(
      "Document REST endpoint",
      "Make sure those front-\nenders can do their \njobs",
      TicketStatus.Done
    ));
  }
}