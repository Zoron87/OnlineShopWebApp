using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Providers;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public HomeController(IProductStorage productStorage, DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ActionResult Index()
        {
            var productsViewModel = _databaseContext.Products.Include(p => p.ImagesPath).ToList().ToProductsViewModel();
            return productsViewModel != null ? View(productsViewModel) : View("Error");
        }
    }
}
