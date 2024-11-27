using GloboTicket.App.Models;
using GloboTicket.App.Services.Interfaces;
using GloboTicket.App.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;

namespace GloboTicket.App.Pages;

public partial class ShoppingCartPage
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    [Inject]
    private IShoppingCartService ShoppingCartService { get; set; } = null!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    private ComponentStateChangedObserver Observer { get; set; } = null!;

    private Guid _userId = Guid.Empty;

    private HashSet<CartItem> cartItems = new HashSet<CartItem>();

    protected override async Task OnInitializedAsync()
    {
        AuthenticationState state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = state.User;
        var userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;
        if (!userId.IsNullOrEmpty())
        {
            _userId = Guid.Parse(userId!);
        }

        await Observer.NotifyStateChangedAsync();

        cartItems = await ShoppingCartService.GetAllItemsAsync(_userId);
    }

    protected async Task RemoveItem(int eventId)
    {
        await ShoppingCartService.RemoveItemAsync(_userId, eventId);

        cartItems = await ShoppingCartService.GetAllItemsAsync(_userId);



        await Observer.NotifyStateChangedAsync();
    }

    protected void NavigateBackToHome()
    {
        NavigationManager.NavigateTo("/");
    }

    protected async Task UpdateItem(CartItem cartItem)
    {
        bool updated = await ShoppingCartService.AddOrUpdateItemAsync(_userId, cartItem.EventId, cartItem.Quantity);

        if (updated)
        {
            cartItems = await ShoppingCartService.GetAllItemsAsync(_userId);

            await Observer.NotifyStateChangedAsync();

            StateHasChanged();
        }
    }

    private void PlaceOrder()
    {
        NavigationManager.NavigateTo("/checkout");
    }
}
