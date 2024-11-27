using GloboTicket.App.Models;
using GloboTicket.App.Services.Interfaces;

namespace GloboTicket.App.Services;

public class OrderService : IOrderService
{
    public Task<List<OrderBase>> GetAllOrdersForUser(Guid userId)
    {
        // TODO: Get all orders for user
        return Task.FromResult(new List<OrderBase>());
    }

    public Task<Order?> GetOrderDetails(long orderId)
    {
        // TODO: Get order by id
        return Task.FromResult((Order?)null);
    }
}
