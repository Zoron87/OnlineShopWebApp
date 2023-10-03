using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductStorage productStorage = new ProductStorageInJson();
        public IActionResult Index(int id)
        {
            var product = productStorage.TryGetById(id);

            return product != null ? View(product) : View("Error");
        }

        public IActionResult View(int page = 1, int itemsonpage = 1)
        {
            var products = productStorage.GetProductsWithPagination(page, itemsonpage);

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
    }
}