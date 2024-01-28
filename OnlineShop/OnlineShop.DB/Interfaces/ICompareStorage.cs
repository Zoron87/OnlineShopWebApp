using OnlineShop.DB.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShop.DB.Interfaces
{
    public interface ICompareStorage
    {
        Task<Compare> TryGetByIdAsync(Guid userId);
        Task AddAsync(Guid userId, Guid productId);
        Task DeleteAsync(Guid userId, Guid productId);
        Task ClearAsync(Guid userId);
    }
}
