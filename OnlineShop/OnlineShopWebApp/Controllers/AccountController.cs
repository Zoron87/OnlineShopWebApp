using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
		private readonly IOrderStorage _orderStorage;
        private readonly UserViewModel _userViewModel;
        private readonly ImageProvider _imageProvider;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager, IOrderStorage orderStorage, UserViewModel userViewModel, ImageProvider imageProvider, IMapper mapper)
        {
            _userManager = userManager;
            _orderStorage = orderStorage;
            _userViewModel = userViewModel;
            _imageProvider = imageProvider;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

		public async Task<IActionResult> GetOrdersAsync()
		{
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
			var orders = await _orderStorage.TryGetByUserIdAsync(userId);
            var ordersViewModel = _mapper.Map<List<OrderViewModel>>(orders);
			return View("Orders", ordersViewModel);
		}

        public async Task<IActionResult> OrderDetailsAsync(Guid orderId)
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            var order = (await _orderStorage.GetAllAsync()).FirstOrDefault(o => o.Id == orderId);
            var orderViewModel = _mapper.Map<OrderViewModel>(order);
            return View(orderViewModel);
        }

        public async Task<IActionResult> EditAsync(Guid orderId)
        {
            var userId = (await _userManager.GetUserAsync(User)).Id;
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            var profileViewModel = _mapper.Map<ProfileViewModel>(user);
            return View(profileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(ProfileViewModel profileViewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = (await _userManager.GetUserAsync(User)).Id; 
                var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);

                if (profileViewModel.UploadedFile != null)
                    user.AvatarImagepath = _imageProvider.AddAvatarImage(profileViewModel);

                var result = await _userManager.UpdateAsync(_mapper.Map(profileViewModel, user));
                return RedirectToAction("Index");
            }
            return View("Edit", profileViewModel);
        }

        public async Task<IActionResult> DeleteAvatarAsync(string userId)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
            user.AvatarImagepath = Constants.BlankAvatar;
            var result = await _userManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }
    }
}
