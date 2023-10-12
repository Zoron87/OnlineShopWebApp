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
            var compareProducts = compareStorage.GetAll();
            return View(compareProducts);
        }

        public ActionResult Add(int productId)
        {
            var compareProducts = compareStorage.Add(productId);

            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            var compareProducts = compareStorage.Clear();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int productId)
        {
            var compareProducts = compareStorage.Delete(productId);

            return RedirectToAction("Index");
        }
    }
}
