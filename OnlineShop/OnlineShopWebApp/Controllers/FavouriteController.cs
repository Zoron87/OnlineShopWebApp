using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class FavouriteController : Controller
	{
		private readonly IFavouriteStorage _favouriteStorage;
        private readonly UserViewModel _userViewModel;
        private readonly UserManager<User> _userManager;

        public FavouriteController(IFavouriteStorage favouriteStorage, UserViewModel userViewModel, UserManager<User> userManager)
        {
            _favouriteStorage = favouriteStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
		{
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            var favouriteProductsViewModel = (await _favouriteStorage.TryGetByIdAsync(userId))?.ToFavouriteViewModel();
            return View(favouriteProductsViewModel);
        }

		public async Task<IActionResult> Add(Guid productId)
		{
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            await _favouriteStorage.AddAsync(userId, productId);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(Guid productId)
		{
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            await _favouriteStorage.DeleteAsync(userId, productId);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Clear()
		{
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            await _favouriteStorage.ClearAsync(userId);
			return RedirectToAction("Index");
		}
	}
}
