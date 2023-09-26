using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IProductStorage
    {
        public bool SaveAll(bool isAppend = false);

        public List<Product> GetAll();

        public Product TryGetById(int id);
    }
}
