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
		private readonly IOrderStorage _orderStorage;
		private readonly ICartStorage _cartStorage;
        private readonly UserViewModel _userViewModel;

        public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage, UserViewModel userViewModel)
		{
			this._cartStorage = cartStorage;
			this._orderStorage = orderStorage;
			this._userViewModel = userViewModel;
        }

        public ActionResult Index()
		{
			var orders = _orderStorage.GetAll();
            return View(orders);
		}

		public ActionResult Details()
		{
			var order = _orderStorage.TryGetById(_userViewModel.Id);
            var cart = _cartStorage.TryGetById(_userViewModel.Id);
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

            var order = _orderStorage.GetAll().FirstOrDefault(el => el.UserId == _userViewModel.Id);
			var cart = _cartStorage.TryGetById(_userViewModel.Id);

			if (order == null)
				order = new Order() { UserId = _userViewModel.Id };

			order.OrderDetails = new OrderDetails() { Items = cart.Items };
            _orderStorage.Mapping(order, orderDetailsViewModel.ToOrderDetails());

			if (ModelState.IsValid)
			{
                _orderStorage.Add(order);
                _cartStorage.Clear(_userViewModel.Id);
                return View("ThankYou");
			}
            return View("Details", order.ToOrderDetailsViewModel());
        }
    }
}