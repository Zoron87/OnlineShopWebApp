using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IProductStorage
    {
        public void SaveAll(bool isAppend = false);

        public List<Product> GetAll();

        public Product TryGetById(int id);
    }
}
