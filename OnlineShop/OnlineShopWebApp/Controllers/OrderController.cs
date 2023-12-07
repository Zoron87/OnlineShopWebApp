using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
		private readonly UserManager<User> _userManager;

        public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage, UserViewModel userViewModel, UserManager<User> userManager)
        {
            _cartStorage = cartStorage;
            _orderStorage = orderStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
        }

        public IActionResult Index()
		{
			var orders = _orderStorage.GetAll();
            return View(orders);
		}

		public IActionResult Details()
		{
            var userId = User.Identity.IsAuthenticated ? Guid.Parse(_userManager.GetUserAsync(User).Result.Id) : _userViewModel.Id;
            var cart = _cartStorage.TryGetById(userId);
            var orderDetailViewModel = new OrderDetails(){ Items = cart.Items, DeliveryDate = DateTime.Now }.ToOrderViewModel();
			return View(orderDetailViewModel);
        }

		public IActionResult ThankYou()
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

            var userId = User.Identity.IsAuthenticated ? Guid.Parse(_userManager.GetUserAsync(User).Result.Id) : _userViewModel.Id;

			var order = new Order() { UserId = userId };
            var cart = _cartStorage.TryGetById(userId);	

			order.OrderDetails = new OrderDetails() { Items = cart.Items };
            _orderStorage.Mapping(order, orderDetailsViewModel.ToOrderDetails());

			if (ModelState.IsValid)
			{
                _orderStorage.Add(order);
                _cartStorage.Clear(userId);
                return View("ThankYou");
			}
            return View("Details", order.ToOrderDetailsViewModel());
        }
    }
}