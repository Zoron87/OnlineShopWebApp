using OnlineShop.DB.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Interfaces
{
    public interface IFavouriteStorage
    {
        Task<Favourite> TryGetByIdAsync(Guid userId);
        Task AddAsync(Guid userId, Guid productId);
        Task DeleteAsync(Guid userId, Guid productId);
        Task ClearAsync(Guid userId);
    }
}
