using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

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
            var products = productStorage.GetAll();

            return products != null ? View(products) : View("Error");
        }
    }
}
