using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System.Collections.Generic;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartStorage _cartStorage;
        private readonly UserViewModel _userViewModel;

        public CartViewComponent(ICartStorage cartStorage, UserViewModel userViewModel)
        {
            this._cartStorage = cartStorage;
            this._userViewModel = userViewModel;
        }
        public IViewComponentResult Invoke()
        {
            var cartViewModel = _cartStorage.TryGetById(_userViewModel.Id)?.ToCartViewModel();
            var productCounts = cartViewModel?.Amount ?? 0;
            return View("Cart", productCounts);
        }
    }
}
