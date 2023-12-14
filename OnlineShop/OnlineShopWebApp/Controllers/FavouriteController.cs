using AutoMapper;
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
        private readonly IMapper _mapper;

        public FavouriteController(IFavouriteStorage favouriteStorage, UserViewModel userViewModel, UserManager<User> userManager, IMapper mapper)
        {
            _favouriteStorage = favouriteStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
		{
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(User)).Id) : _userViewModel.Id;
            var favouriteProducts = await _favouriteStorage.TryGetByIdAsync(userId);
            var favouriteProductsViewModel = _mapper.Map<FavouriteViewModel>(favouriteProducts);
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
