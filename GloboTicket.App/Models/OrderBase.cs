namespace GloboTicket.App.Models;

public class OrderBase
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public decimal OrderTotal { get; set; }

    public DateTime OrderPlaced { get; set; }

    public PaymentStatusEnum PaymentStatus { get; set; }
}