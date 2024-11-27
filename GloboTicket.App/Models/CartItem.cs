namespace GloboTicket.App.Models;

public class CartItem
{
    public int Quantity { get; set; }

    public int EventId { get; set; }

    public string EventName { get; set; } = string.Empty;

    public DateTime EventDate { get; set; }

    public decimal Price { get; set; }

    public decimal TotalPrice => Math.Round((decimal)Quantity * Price, 2, MidpointRounding.AwayFromZero);
}