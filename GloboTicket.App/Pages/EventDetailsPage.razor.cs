using GloboTicket.App.Models;
using GloboTicket.App.Services.Interfaces;
using GloboTicket.App.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;

namespace GloboTicket.App.Pages;

public partial class EventDetailsPage
{
    [Inject]
    private IEventCatalogService EventCatalogService { get; set; } = default!;

    [Inject]
    private IShoppingCartService ShoppingCartService { get; set; } = default!;

    [Inject]
    private ComponentStateChangedObserver Observer { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    [Parameter]
    public int Id { get; set; }

    private EventDetails? EventDetails { get; set; }

    private Guid _userId = Guid.Empty;

    private int _purchaseAmount = 1;

    protected override async Task OnInitializedAsync()
    {
        AuthenticationState state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = state.User;
        var userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;
        if (!userId.IsNullOrEmpty())
        {
            _userId = Guid.Parse(userId!);
        }

        EventDetails = await EventCatalogService.GetEvent(Id);
    }

    private async Task AddToCart(int quantity)
    {
        if (await ShoppingCartService.AddOrUpdateItemAsync(_userId, EventDetails!.Id, quantity))
        {
            NavigationManager.NavigateTo("/");

            await Observer.NotifyStateChangedAsync();

            StateHasChanged();
        }
    }

    private void UpdatePurchaseAmount(ChangeEventArgs e)
    {
        _purchaseAmount = int.Parse(e.Value?.ToString() ?? "0");
    }
}
