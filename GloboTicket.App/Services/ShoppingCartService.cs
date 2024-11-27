using GloboTicket.App.Models;
using GloboTicket.App.Services.Interfaces;

namespace GloboTicket.App.Services;

public class ShoppingCartService : IShoppingCartService
{
    public Task<bool> AddOrUpdateItemAsync(Guid userId, int eventId, int quantity)
    {
        if (userId == Guid.Empty)
        {
            return Task.FromResult(false);
        }

        // TODO: Add or update item
        return Task.FromResult(false);
    }

    public async Task<int> GetCountAsync(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            return 0;
        }

        // TODO: get total items in cart
        return 0;
    }

    public Task<HashSet<CartItem>> GetAllItemsAsync(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            return Task.FromResult(new HashSet<CartItem>());
        }

        // TODO: Get all cartItems

        return Task.FromResult(new HashSet<CartItem>());
    }

    public Task<bool> PlaceOrder(Guid userId, PaymentDetails paymentDetails)
    {
        if (userId == Guid.Empty)
        {
            return Task.FromResult(false);
        }

        // TODO: place order
        return Task.FromResult(false);
    }

    public Task RemoveItemAsync(Guid userId, int eventId)
    {
        if (userId == Guid.Empty)
        {
            return Task.CompletedTask;
        }

        // TODO: remove item
        return Task.CompletedTask;
    }
}