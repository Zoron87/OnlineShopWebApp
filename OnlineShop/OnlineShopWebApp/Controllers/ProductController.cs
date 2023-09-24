using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
	{
        private ProductRepository productRepository = new ProductRepository();
        public string Index(int id)
		{
			var currentProduct = productRepository.TryGetById(id);
			return (currentProduct != null) ? currentProduct.ToString() : $"Продукт с id {id} не найден";
		}
	}
}
