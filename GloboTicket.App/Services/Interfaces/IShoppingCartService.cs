using GloboTicket.App.Models;

namespace GloboTicket.App.Services.Interfaces;

public interface IShoppingCartService
{
    Task<bool> AddOrUpdateItemAsync(Guid userId, int eventId, int quantity);

    Task<int> GetCountAsync(Guid userId);

    Task<HashSet<CartItem>> GetAllItemsAsync(Guid userId);

    Task<bool> PlaceOrder(Guid userId, PaymentDetails paymentDetails);

    Task RemoveItemAsync(Guid userId, int eventId);
}