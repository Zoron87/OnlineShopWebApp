using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class ProductRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product("Name1", 100, "Description1"),
            new Product("Name2", 200, "Description2"),
            new Product("Name3", 300, "Description3")
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}
