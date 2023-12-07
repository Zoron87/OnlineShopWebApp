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
	public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
		private readonly IOrderStorage _orderStorage;
        private readonly UserViewModel _userViewModel;

        public AccountController(UserManager<User> userManager, IOrderStorage orderStorage, UserViewModel userViewModel)
        {
            _userManager = userManager;
            _orderStorage = orderStorage;
            _userViewModel = userViewModel;
        }

        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return View(user);
        }

		public IActionResult GetOrders()
		{
            var userId = User.Identity.IsAuthenticated ? Guid.Parse(_userManager.GetUserAsync(User).Result.Id) : _userViewModel.Id;
			var ordersViewModel = _orderStorage.TryGetByUserId(userId).ToOrdersViewModel();
			return View("Orders", ordersViewModel);
		}

        public IActionResult Details(Guid orderId)
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse(_userManager.GetUserAsync(User).Result.Id) : _userViewModel.Id;
            //var orderDetailViewModel = new OrderDetails() { Items = cart.Items, DeliveryDate = DateTime.Now }.ToOrderViewModel();
            var orderDetailViewModel = _orderStorage.GetAll().FirstOrDefault(o => o.Id == orderId).ToOrderViewModel();
            return View(orderDetailViewModel);
        }
    }
}
