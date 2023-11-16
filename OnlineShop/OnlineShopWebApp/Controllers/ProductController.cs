using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Providers;
using System;
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

        public IActionResult Index(Guid productId)
        {
            var product = productStorage.TryGetById(productId).ToProductViewModel();
            return product != null ? View(product) : View("Error");
        }

        public IActionResult View(int page = 1, int itemsOnPage = 1)
        {
            var products = productStorage.GetProductsWithPagination(page, itemsOnPage).ToProductsViewModel();
            return products != null ? View(products) : View("Error");
        }

        public IActionResult Search(string search) 
        {
            ViewData["Search"] = search;
            search = search.ToLower();
            var productsViewModel = productStorage.GetAll().Where(p => p.Name.ToLower().Contains(search) || p.Description.ToLower().Contains(search)).ToList().ToProductsViewModel();

            return View(productsViewModel);
        }
    }
}