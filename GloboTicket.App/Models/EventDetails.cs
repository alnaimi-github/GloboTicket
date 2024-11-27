namespace GloboTicket.App.Models;

public record EventDetails
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string Artist { get; set; } = null!;
        
    public DateTime Date { get; set; }

    public string Description { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public EventCategory Category { get; set; }

    public int TotalTickets { get; set; }

    public int AvailableTickets { get; set; }
}