using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IProductStorage
    {
        bool SaveAll(bool isAppend = false);
        List<Product> GetAll();
        Product TryGetById(int id);
        List<Product> GetProductsWithPagination(int page, int itemsOnPage);
    }
}
