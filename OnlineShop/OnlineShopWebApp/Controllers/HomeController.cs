using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProductStorage productStorage;
		private readonly ICartStorage cartStorage;
		private readonly IFavouriteStorage favouriteStorage;

		public HomeController(IProductStorage productStorage, ICartStorage cartStorage, IFavouriteStorage favouriteStorage)
		{
			this.productStorage = productStorage;
			this.cartStorage = cartStorage;
			this.favouriteStorage = favouriteStorage;
		}

		public ActionResult Index()
		{
			var products = productStorage.GetAll();



			return products != null ? View(products) : View("Error");
		}
	}
}
