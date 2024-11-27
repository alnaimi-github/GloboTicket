using GloboTicket.App.Models;

namespace GloboTicket.App.Services.Interfaces;

public interface IEventCatalogService
{
    Task<List<EventDetails>> GetAllEventsAsync();

    Task<EventDetails> GetEvent(int id);

    Task<List<EventDetails>> GetEventsByCategory(EventCategory category);
}