using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.DB.Interfaces
{
    public interface IProductStorage
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> TryGetByIdAsync(Guid id);
        Task<List<Product>> GetProductsWithPaginationAsync(int page, int itemsOnPage);
        Task SaveChangeAsync();
        Task DeleteAsync(Guid productId);
        Task AddAsync(Product product);
    }
}
