using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
	{
		private readonly IOrderStorage orderStorage;
		private readonly ICartStorage cartStorage;

		public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage)
		{
			this.cartStorage = cartStorage;
			this.orderStorage = orderStorage;
		}
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Details()
		{
			return View();
		}

		public ActionResult ThankYou()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(OrderDetails orderDetails)
		{
			var cart = cartStorage.Get(ShopUser.Id);

			if (cart != null && orderDetails != null)
			{
				//var order = new Order(orderDetails, cart);
				orderStorage.Add(orderDetails, cart);
                cart.Items.Clear();

				return View("ThankYou");
			}

			return View("Error");
		}
	}
}
