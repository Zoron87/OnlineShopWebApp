using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;

namespace OnlineShopWebApp.Views.Shared.Components.CartInfoFull
{
    public class CartInfoFullViewComponent : ViewComponent
    {
        private readonly ICartStorage _cartStorage;
        private readonly UserViewModel _userViewModel;
        private readonly UserManager<User> _userManager;

        public CartInfoFullViewComponent(ICartStorage cartStorage, UserViewModel userViewModel, UserManager<User> userManager)
        {
            _cartStorage = cartStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse(_userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User).Result.Id) : _userViewModel.Id;
            var cartViewModel = _cartStorage.TryGetById(userId)?.ToCartViewModel();
            return View("CartInfoFull", cartViewModel);
        }
    }
}
