using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.Components.Favourite
{
    public class FavouriteViewComponent : ViewComponent
    {
        private readonly IFavouriteStorage _favouriteStorage;
        private readonly UserViewModel _userViewModel;
        private readonly UserManager<User> _userManager;

        public FavouriteViewComponent(IFavouriteStorage favouriteStorage, UserViewModel userViewModel, UserManager<User> userManager)
        {
            _favouriteStorage = favouriteStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User)).Id) : _userViewModel.Id;
            var favouriteProductsViewModel = (await _favouriteStorage.TryGetByIdAsync(userId))?.ToFavouriteViewModel();
            return View("Favourite", favouriteProductsViewModel?.Amount ?? 0);
        }
    }
}
