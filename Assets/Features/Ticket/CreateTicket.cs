using UnityEngine;

public enum TicketStatus
{
  Planned, Doing, Reviewing, Done
}

public struct Ticket
{
  public string title, body;
  public TicketStatus status;

  public Ticket(string t, string b, TicketStatus s)
  {
    title = t;
    body = b;
    status = s;
  }
}

public class CreateTicket : MonoBehaviour
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
