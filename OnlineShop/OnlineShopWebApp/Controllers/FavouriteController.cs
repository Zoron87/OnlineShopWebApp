using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly IFavouriteStorage favouriteStorage;

        public FavouriteController(IFavouriteStorage favouriteStorage)
        {
            this.favouriteStorage = favouriteStorage;
        }
        public ActionResult Index()
        {
            var favouriteProducts = favouriteStorage.GetAll();
            return View(favouriteProducts);
        }

        public ActionResult Add(int productId)
        {
            var favouriteProducts = favouriteStorage.Add(productId);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int productId)
        {
            var favouriteProducts = favouriteStorage.Delete(productId);
            return RedirectToAction("Index");
        }

        public ActionResult Clear(int productId)
        {
            var favouriteProducts = favouriteStorage.Clear();
            return RedirectToAction("Index");
        }
    }
}
