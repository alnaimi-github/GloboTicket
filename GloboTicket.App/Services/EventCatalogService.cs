using GloboTicket.App.Models;
using GloboTicket.App.Services.Interfaces;

namespace GloboTicket.App.Services;

public class EventCatalogService : IEventCatalogService
{
    public async Task<List<EventDetails>> GetAllEventsAsync()
    {
        // TODO: Get events
        return new List<EventDetails>();
    }

    public Task<EventDetails> GetEvent(int id)
    {
        // TODO: Get event by Id
        return Task.FromResult(new EventDetails());
    }

    public async Task<List<EventDetails>> GetEventsByCategory(EventCategory category)
    {
        // TODO: Get events by category
        return new List<EventDetails>();
    }
}