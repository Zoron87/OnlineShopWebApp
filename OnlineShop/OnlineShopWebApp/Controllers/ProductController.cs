using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Providers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductStorage _productStorage;

        public ProductController(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }

        public async Task<IActionResult> Index(Guid productId)
        {
            var product = (await _productStorage.TryGetByIdAsync(productId)).ToProductViewModel();
            return product != null ? View(product) : View("Error");
        }

        public async Task<IActionResult> ViewAsync(int page = 1, int itemsOnPage = 1)
        {
            var products = (await _productStorage.GetProductsWithPaginationAsync(page, itemsOnPage)).ToProductsViewModel();
            return products != null ? View(products) : View("Error");
        }

        public async Task<IActionResult> SearchAsync(string search) 
        {
            ViewData["Search"] = search;
            search = search.ToLower();
            var productsViewModel = (await _productStorage.GetAllAsync()).Where(p => p.Name.ToLower().Contains(search) || p.Description.ToLower().Contains(search)).ToList().ToProductsViewModel();
            return View(productsViewModel);
        }
    }
}