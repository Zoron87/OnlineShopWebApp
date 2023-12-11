using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Providers;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public HomeController(IProductStorage productStorage, DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IActionResult> Index()
        {
            var productsViewModel = (await _databaseContext.Products.Include(p => p.ImagesPath).ToListAsync()).ToProductsViewModel();
            return productsViewModel != null ? View(productsViewModel) : View("Error");
        }
    }
}
