namespace GloboTicket.App.Models;

public class OrderLine
{
    public int Id { get; set; }

    public long OrderId { get; set; }

    public int EventId { get; set; }

    public string EventName { get; set; } = string.Empty;

    public int TicketAmount { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice => Math.Round((decimal)TicketAmount * UnitPrice, 2, MidpointRounding.AwayFromZero);
}