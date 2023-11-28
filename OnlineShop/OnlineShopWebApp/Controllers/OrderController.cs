using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class OrderController : Controller
	{
		private readonly IOrderStorage orderStorage;
		private readonly ICartStorage cartStorage;
        private readonly UserViewModel userViewModel;

        public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage, UserViewModel userViewModel)
		{
			this.cartStorage = cartStorage;
			this.orderStorage = orderStorage;
			this.userViewModel = userViewModel;
        }

        public ActionResult Index()
		{
			var orders = orderStorage.GetAll();
            return View(orders);
		}

		public ActionResult Details()
		{
			var order = orderStorage.TryGetById(userViewModel.Id);
            var cart = cartStorage.TryGetById(userViewModel.Id);
            var orderDetailViewModel = new OrderDetails(){ Items = cart.Items, DeliveryDate = DateTime.Now }.ToOrderViewModel();
			return View(orderDetailViewModel);
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

            var order = orderStorage.GetAll().FirstOrDefault(el => el.UserId == userViewModel.Id);
			var cart = cartStorage.TryGetById(userViewModel.Id);

			if (order == null)
				order = new Order() { UserId = userViewModel.Id };

			order.OrderDetails = new OrderDetails() { Items = cart.Items };
            orderStorage.Mapping(order, orderDetailsViewModel.ToOrderDetails());

			if (ModelState.IsValid)
			{
                orderStorage.Add(order);
                cartStorage.Clear(userViewModel.Id);
                return View("ThankYou");
			}
            return View("Details", order.ToOrderDetailsViewModel());
        }
    }
}