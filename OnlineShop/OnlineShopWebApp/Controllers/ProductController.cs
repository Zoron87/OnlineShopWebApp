using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductStorage productStorageInJson = new ProductStorageInJson();
        public IActionResult Index(int id)
        {
            var product = productStorageInJson.TryGetById(id);

            return (product != null) ? View(product) : View("Error");
        }

        public IActionResult View(int page = 1, int itemsonpage = 1)
        {
            var products = productStorageInJson.GetProductsWithPagination(page, itemsonpage);

            return (products != null) ? View(products) : View("Error");
        }

        public string SaveAll(bool isAppend = false)
        {
            if (productStorageInJson.SaveAll(isAppend))
                return "Успешно сохранили информацию в файл!";

            return "Ошибка сохранения информации в файл!";
        }

        public IActionResult GetAll()
        {
            var allProducts = productStorageInJson.GetAll();

            return (allProducts != null) ? View(allProducts) : View("Error");
        }
    }
}