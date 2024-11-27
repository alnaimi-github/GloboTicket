using GloboTicket.App.Models;
using GloboTicket.App.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.App.Pages;

public partial class OrderDetailsPage
{
    [Parameter]
    public long OrderId { get; set; }

    [Inject]
    private IOrderService OrderService { get; set; } = default!;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    private Order? order { get; set; }

    protected override async Task OnInitializedAsync()
    {
        order = await OrderService.GetOrderDetails(OrderId);
    }

    private void NavigateBackToOrders()
    {
        NavigationManager.NavigateTo("/orders");
    }
}
