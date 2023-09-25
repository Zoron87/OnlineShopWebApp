using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Repositories;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductStorage productStorageInJson = new ProductStorageInJson();
        public string Index(int id)
        {
            var currentProduct = productStorageInJson.TryGetById(id);
            return (currentProduct != null) ? currentProduct.ToString() : $"Продукт с id {id} не найден";
        }

        public string SaveAll(bool isAppend = false)
        {
            productStorageInJson.SaveAll(isAppend);
            return "Успешно сохранили информацию в файл!";
        }

        public string GetAll()
        {
            var allProducts = productStorageInJson.GetAll();
            return String.Join("\n", allProducts);
        }
    }
}
