using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Controllers
{
	public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
		private readonly IOrderStorage _orderStorage;

		public AccountController(UserManager<User> userManager, IOrderStorage orderStorage)
		{
			_userManager = userManager;
			_orderStorage = orderStorage;
		}

		public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            return View(user);
        }

		public IActionResult GetOrders()
		{
			var user = _userManager.FindByEmailAsync(User.Identity.Name).Result;
			var orders = _orderStorage.TryGetByUserId(user.Id);
			return View("Orders", orders);
		}
	}
}
