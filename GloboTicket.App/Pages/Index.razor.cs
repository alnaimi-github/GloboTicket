using GloboTicket.App.Models;
using GloboTicket.App.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.App.Pages;

public partial class Index
{
    private List<EventDetails> _events = new List<EventDetails>();

    private List<string> _categories = new List<string>();

    [Inject] public IEventCatalogService EventCatalogService { get; set; } = null!;

    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        _events = await EventCatalogService.GetAllEventsAsync();

        _categories = Enum.GetNames(typeof(EventCategory)).ToList();
    }

    private async Task CategorySelected(ChangeEventArgs e)
    {
        string selectedCategory = e.Value?.ToString() ?? string.Empty;
        if (selectedCategory.Equals("All") || selectedCategory == string.Empty)
        {
            _events = await EventCatalogService.GetAllEventsAsync();
        }
        else
        {
            _events = await EventCatalogService.GetEventsByCategory(Enum.Parse<EventCategory>(selectedCategory));
        }
    }

    private void NavigateToEventDetails(int eventId)
    {
        NavigationManager.NavigateTo($"Events/{eventId}");
    }
}