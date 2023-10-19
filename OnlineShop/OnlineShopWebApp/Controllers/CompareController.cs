using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

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
            var products = compareStorage.TryGetById(ShopUser.Id);
            return View(products);
        }

        public ActionResult Add(int productId)
        {
            compareStorage.Add(ShopUser.Id, productId);

            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            compareStorage.Clear(ShopUser.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int productId)
        {
            compareStorage.Delete(ShopUser.Id, productId);

            return RedirectToAction("Index");
        }
    }
}
