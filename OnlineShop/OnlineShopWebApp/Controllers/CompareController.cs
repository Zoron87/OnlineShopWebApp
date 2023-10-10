using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private ICompareStorage compareStorage;

        public CompareController(ICompareStorage compareStorage)
        {
            this.compareStorage = compareStorage;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(int productId)
        {
            var compareProducts = compareStorage.Add(productId);

            return View("Index", compareProducts);
        }

        public ActionResult Clear()
        {
            var compareProducts = compareStorage.Clear();

            return View("Index", compareProducts);
        }

        public ActionResult DeleteItem(int productId)
        {
            var compareProducts = compareStorage.DeleteItem(productId);

            return View("Index", compareProducts);
        }
    }
}
