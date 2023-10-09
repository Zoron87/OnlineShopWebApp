using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Storages;

namespace OnlineShopWebApp.Controllers
{
	public class OrderController : Controller
    {
		//private readonly ICartStorage cartStorage;
		private readonly Cart cart;
		OrderItem orderDetails = new OrderItem();

		public OrderController(ICartStorage cartStorage)
        {
			//this.cartStorage = cartStorage;
            cart = cartStorage.TryGetById(ShopUser.Id);
		}
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

		public ActionResult Thankyou()
		{
			return View();
		}

		[HttpPost]
        public IActionResult Index(OrderItem orderDetails)
        {
            var order = new OrderStorage(orderDetails, cart);
            order.Save();
            return View("Thankyou");
        }

    }
}
