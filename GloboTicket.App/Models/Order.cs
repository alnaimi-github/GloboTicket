namespace GloboTicket.App.Models;

public class Order : OrderBase
{
    public List<OrderLine> OrderLines { get; set; } = new();
}