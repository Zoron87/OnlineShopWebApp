using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
	{
		private readonly IOrderStorage orderStorage;
        private readonly ShopUser shopUser;
        private readonly ICartStorage cartStorage;

		public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage, ShopUser shopUser)
		{
			this.cartStorage = cartStorage;
			this.orderStorage = orderStorage;
            this.shopUser = shopUser;
        }
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Details()
		{
            var cart = cartStorage.TryGetById(shopUser.Id);

            if (cart != null)
                return View(cart);
			return View("Error");
		}

		public ActionResult ThankYou()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(OrderDetails orderDetails)
		{
			if (orderDetails.Name == null || orderDetails.Name.Any(c => char.IsDigit(c)))
				ModelState.AddModelError("", "В имени получателя допустимо использовать только буквы");

			if (orderDetails.DeliveryDate <= DateTime.Now)
				ModelState.AddModelError("", "Нельзя выбрать дату доставки ранее текущей");

			if (ModelState.IsValid)
			{
				var cart = cartStorage.TryGetById(shopUser.Id);

				if (cart != null && orderDetails != null)
				{
					orderStorage.Add(orderDetails, cart);
					cart.Items.Clear();
					return View("ThankYou");
				}
			}

            return View(orderDetails);
        }
    }
}