using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	public class FavouriteController : Controller
	{
		private readonly IFavouriteStorage favouriteStorage;
        private readonly ShopUser shopUser;

        public FavouriteController(IFavouriteStorage favouriteStorage, ShopUser shopUser)
        {
			this.favouriteStorage = favouriteStorage;
            this.shopUser = shopUser;
        }
		public ActionResult Index()
		{
			var products = favouriteStorage.TryGetById(shopUser.Id);
			return View(products);
		}

		public ActionResult Add(int productId)
		{
			favouriteStorage.Add(shopUser.Id, productId);
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int productId)
		{
			favouriteStorage.Delete(shopUser.Id, productId);
			return RedirectToAction("Index");
		}

		public ActionResult Clear()
		{
			favouriteStorage.Clear(shopUser.Id);
			return RedirectToAction("Index");
		}
	}
}
