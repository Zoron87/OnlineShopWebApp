using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private readonly ICompareStorage compareStorage;
        private readonly IProductStorage productStorage;

        public CompareController(ICompareStorage compareStorage, IProductStorage productStorage)
        {
            this.compareStorage = compareStorage;
            this.productStorage = productStorage;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int productId)
        {
            var product = productStorage.TryGetById(productId);
            compareStorage.Add(product);
            return View();
        }
    }
}
