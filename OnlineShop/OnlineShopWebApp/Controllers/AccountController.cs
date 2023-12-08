using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
		private readonly IOrderStorage _orderStorage;
        private readonly UserViewModel _userViewModel;
        private readonly ImageProvider _imageProvider;

        public AccountController(UserManager<User> userManager, IOrderStorage orderStorage, UserViewModel userViewModel, ImageProvider imageProvider)
        {
            _userManager = userManager;
            _orderStorage = orderStorage;
            _userViewModel = userViewModel;
            _imageProvider = imageProvider;
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

        public IActionResult OrderDetails(Guid orderId)
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse(_userManager.GetUserAsync(User).Result.Id) : _userViewModel.Id;
            var orderDetailViewModel = _orderStorage.GetAll().FirstOrDefault(o => o.Id == orderId).ToOrderViewModel();
            return View(orderDetailViewModel);
        }

        public IActionResult Edit(Guid orderId)
        {
            var userId = _userManager.GetUserAsync(User).Result.Id;
            var userViewModel = _userManager.Users.FirstOrDefault(u => u.Id == userId).ToProfileViewModel();
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult Save(ProfileViewModel profileViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserAsync(User).Result.Id;
                var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
                
                if (profileViewModel.UploadedFile != null)
                    user.AvatarImagepath = _imageProvider.AddAvatarImage(profileViewModel);

                var result = _userManager.UpdateAsync(profileViewModel.ToUser(user)).Result;
                return RedirectToAction("Index");
            }
            return View("Save", profileViewModel);
        }

        public IActionResult DeleteAvatar(string userId)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            user.AvatarImagepath = Constants.BlankAvatar;
            var result = _userManager.UpdateAsync(user).Result;

            return RedirectToAction("Index");
        }
    }
}
