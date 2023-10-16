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
			var products = favouriteStorage.GetAll();
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
			favouriteStorage.Clear();
			return RedirectToAction("Index");
		}
	}
}
