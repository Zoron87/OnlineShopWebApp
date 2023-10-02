using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        IProductStorage productStorageInJson = new ProductStorageInJson();

        public ActionResult Index()
        {
            var products = productStorageInJson.GetAll();

            return View((object)products);
        }
    }
}
