using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
	{
		private readonly IOrderStorage orderStorage;
		private readonly ICartStorage cartStorage;
        private readonly ShopUser shopUser;

        public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage, ShopUser shopUser)
		{
			this.cartStorage = cartStorage;
			this.orderStorage = orderStorage;
			this.shopUser = shopUser;
        }

        public ActionResult Index()
		{
			var orders = orderStorage.GetAll();
            return View(orders);
		}

		public ActionResult Details()
		{
			var order = orderStorage.TryGetById(shopUser.Id);
            var cart = cartStorage.TryGetById(shopUser.Id);
            var orderMiddleViewModel = new OrderMiddle(){ Items = cart.Items, DeliveryDate = DateTime.Now }.ToOrderViewModel();
			return View(orderMiddleViewModel);
        }

		public ActionResult ThankYou()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(OrderDetailsViewModel orderDetailsViewModel)
		{
			if (orderDetailsViewModel.Name == null || orderDetailsViewModel.Name.Any(c => char.IsDigit(c)))
				ModelState.AddModelError("", "В имени получателя допустимо использовать только буквы");

			if (orderDetailsViewModel.DeliveryDate.AddDays(1) < DateTime.Now)
				ModelState.AddModelError("", "Нельзя выбрать дату доставки ранее текущей");

            var order = orderStorage.GetAll().FirstOrDefault(el => el.UserId == shopUser.Id);
			var cart = cartStorage.TryGetById(shopUser.Id);

			if (order == null)
				order = new Order() { UserId = shopUser.Id };

			order.OrderMiddle = new OrderMiddle() { Items = cart.Items };
            orderStorage.Mapping(order, orderDetailsViewModel.ToOrderDetails());

			if (ModelState.IsValid)
			{
                orderStorage.Add(order);
                cartStorage.Clear(shopUser.Id);
                return View("ThankYou");
			}
            return View("Details", order.ToOrderMiddleViewModel());
        }
    }
}