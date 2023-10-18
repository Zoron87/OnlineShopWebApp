using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProductStorage productStorage;

		public HomeController(IProductStorage productStorage)
		{
			this.productStorage = productStorage;
		}

		public ActionResult Index()
		{
			var products = productStorage.GetAll();

			if (products != null)
				return View(products);

			return View("Error");
		}
	}
}
