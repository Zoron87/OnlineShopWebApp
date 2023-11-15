using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.DB.Interfaces
{
    public interface IProductStorage
    {
        List<Product> GetAll();
        Product TryGetById(Guid id);
        List<Product> GetProductsWithPagination(int page, int itemsOnPage);
        void SaveChange();
        void Delete(Guid productId);
        void Add(Product product);
    }
}
