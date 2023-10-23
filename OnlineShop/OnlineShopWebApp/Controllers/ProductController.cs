using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;

        public ProductController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        public IActionResult Index(int productId)
        {
            var product = productStorage.TryGetById(productId);

            return product != null ? View(product) : View("Error");
        }

        public IActionResult View(int page = 1, int itemsOnPage = 1)
        {
            var products = productStorage.GetProductsWithPagination(page, itemsOnPage);

            return products != null ? View(products) : View("Error");
        }

        public string SaveAll(bool isAppend = false)
        {
            if (productStorage.SaveAll(isAppend))
                return "Успешно сохранили информацию в файл!";

            return "Ошибка сохранения информации в файл!";
        }

        public IActionResult GetAll()
        {
            var allProducts = productStorage.GetAll();

            return allProducts != null ? View(allProducts) : View("Error");
        }

        public IActionResult Search(string search) 
        {
            ViewData["Search"] = search;
            search = search.ToLower();
            var products = productStorage.GetAll().Where(p => p.Name.ToLower().Contains(search) || p.Description.ToLower().Contains(search)).ToList();
            return View(products);
        }
    }
}