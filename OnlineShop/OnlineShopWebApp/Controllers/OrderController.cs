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
			if (orderDetails.Name.Any(c => char.IsDigit(c)))
				ModelState.AddModelError("", "В имени получателя допустимо использовать только буквы");

			if (orderDetails.DeliveryDate <= DateTime.Now)
				ModelState.AddModelError("", "Нельзя выбрать дату доставки ранее текущей");

			if (ModelState.IsValid)
			{
				var cart = cartStorage.TryGetById(ShopUser.Id);

				if (cart != null && orderDetails != null)
				{
					orderStorage.Add(orderDetails, cart);
					cart.Items.Clear();
					return View("ThankYou");
				}
			}

            return View("Details", orderDetails);
        }
    }
}