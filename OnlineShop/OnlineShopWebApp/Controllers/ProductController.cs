using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository productRepository = new ProductRepository();
        public string Index(int id)
        {
            var product = productRepository.TryGetById(id);
            return (product != null) ? product.ToString() : $"Продукт с id {id} не найден";
        }
    }
}
