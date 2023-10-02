using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Repositories;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductStorage productStorageInJson = new ProductStorageInJson();
        public IActionResult Index(int id)
        {
            var product = productStorageInJson.TryGetById(id);
            //product = (product != null) ? product.ToString() : $"Продукт с id {id} не найден";

            return View((object)product);
        }

        public string SaveAll(bool isAppend = false)
        {
            if (productStorageInJson.SaveAll(isAppend))
                return "Успешно сохранили информацию в файл!";


           return "Ошибка сохранения информации в файл!";
        }

        public string GetAll()
        {
            var allProducts = productStorageInJson.GetAll();
            return String.Join("\n", allProducts);
        }
    }
}