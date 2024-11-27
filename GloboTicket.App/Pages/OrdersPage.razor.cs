using GloboTicket.App.Models;
using GloboTicket.App.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;

namespace GloboTicket.App.Pages;

public partial class OrdersPage
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = null!;

    [Inject]
    private IOrderService OrderService { get; set; } = default!;

    private Guid _userId = Guid.Empty;

    private List<OrderBase> orders = new List<OrderBase>();

    protected override async Task OnInitializedAsync()
    {
        AuthenticationState state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = state.User;
        var userId = user.FindFirst(c => c.Type.Contains("nameidentifier"))?.Value;
        if (!userId.IsNullOrEmpty())
        {
            _userId = Guid.Parse(userId!);
        }

        orders = await OrderService.GetAllOrdersForUser(_userId);
    }

    public void GoToDetails(long orderId)
    {
        NavigationManager.NavigateTo($"/orders/{orderId}");
    }
}
