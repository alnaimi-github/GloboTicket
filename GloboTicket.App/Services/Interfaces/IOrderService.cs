using GloboTicket.App.Models;

namespace GloboTicket.App.Services.Interfaces;

public interface IOrderService
{
    Task<List<OrderBase>> GetAllOrdersForUser(Guid userId);

    Task<Order?> GetOrderDetails(long orderId);
}
