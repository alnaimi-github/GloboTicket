using GloboTicket.App.Models;
using GloboTicket.App.Services.Interfaces;
using GloboTicket.App.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;

namespace GloboTicket.App.Pages;

public partial class CheckoutPage
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    private IUserService UserService { get; set; } = default!;

    [Inject]
    private IShoppingCartService ShoppingCartService { get; set; } = default!;

    [Inject]
    private ComponentStateChangedObserver Observer { get; set; } = null!;

    private Guid _userId = Guid.Empty;

    private UserProfile? _profile = null;

    private PaymentDetails _paymentDetails = new PaymentDetails();

    protected override async Task OnInitializedAsync()
    {
        AuthenticationState state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = state.User;
        var userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;
        if (!userId.IsNullOrEmpty())
        {
            _userId = Guid.Parse(userId!);
        }

        _profile = await UserService.GetUserProfile(_userId);
    }

    protected async Task UpdateProfile()
    {
        await UserService.UpdateProfile(_profile);
    }

    protected async Task PlaceOrder()
    {
        bool orderPlaced = await ShoppingCartService.PlaceOrder(_userId, _paymentDetails);

        if (orderPlaced)
        {
            NavigationManager.NavigateTo("/checkout/complete");

            await Observer.NotifyStateChangedAsync();
        }
        else
        {
            NavigationManager.NavigateTo("/checkout/failed");
        }
    }
}
