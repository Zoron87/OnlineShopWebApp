using OnlineShop.DB.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShop.DB.Interfaces
{
    public interface ICartStorage
    {
        Task AddItemAsync(Guid userId, Guid productId, int quantity = 1);
        Task ReduceAsync(Guid userId, Guid productId);
        Task DeleteItemAsync(Guid userId, Guid productId);
        Task<Cart> TryGetByIdAsync(Guid userGuid);
        Task ClearAsync(Guid userId);
        Task<Cart> CreateAsync(Guid userId, CartItem cartItem = null);
    }
}
