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
			{
				var orderMiddle = new OrderMiddle() { Cart = cart };

                if (!orderStorage.CheckBlankEmail(orderMiddle))
                {
					orderStorage.Add(orderMiddle);
				}
				return View(orderMiddle);
			}
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

			if (orderDetails.DeliveryDate.AddDays(1) < DateTime.Now)
				ModelState.AddModelError("", "Нельзя выбрать дату доставки ранее текущей");

            var orders = orderStorage.GetAll();
            var order = orders.FirstOrDefault(el => el.OrderMiddle.Cart.UserId == shopUser.Id && String.IsNullOrEmpty(el.OrderMiddle.Email));
            orderStorage.Mapping(order, orderDetails);

			if (ModelState.IsValid)
			{
				if (orderDetails != null || order != null)
				{
					orderStorage.Delete(order);
                    orderStorage.SaveAll(orders);
					cartStorage.Clear(shopUser.Id);
					return View("ThankYou");
				}
			}

            return View("Details", order.OrderMiddle);
        }
    }
}