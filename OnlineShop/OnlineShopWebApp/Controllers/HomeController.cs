using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductStorage productStorage;

        public HomeController(IProductStorage productStorage)
		{
			this.productStorage = productStorage;
        }

        public ActionResult Index()
        {
            var productsViewModel = productStorage.GetAll().ToProductsViewModel();
            return productsViewModel != null ? View(productsViewModel) : View("Error");
        }
    }
}
