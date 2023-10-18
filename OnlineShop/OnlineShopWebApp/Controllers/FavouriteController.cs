using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

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
			var products = favouriteStorage.Get(ShopUser.Id);
			return View(products);
		}

		public ActionResult Add(int productId)
		{
			favouriteStorage.Add(productId);
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int productId)
		{
			favouriteStorage.Delete(productId);
			return RedirectToAction("Index");
		}

		public ActionResult Clear()
		{
			favouriteStorage.Clear(ShopUser.Id);
			return RedirectToAction("Index");
		}
	}
}
