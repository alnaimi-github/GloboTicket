namespace GloboTicket.App.Models;

public class PaymentDetails
{
    public string CardName { get; set; } = string.Empty;

    public string CardNumber { get; set; } = string.Empty;

    public string CardExpiration { get; set; } = string.Empty;

    public string CvvCode { get; set; } = string.Empty;
}
