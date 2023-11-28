using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System.Collections.Generic;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartStorage cartStorage;
        private readonly UserViewModel userViewModel;

        public CartViewComponent(ICartStorage cartStorage, UserViewModel shopUser)
        {
            this.cartStorage = cartStorage;
            this.userViewModel = shopUser;
        }
        public IViewComponentResult Invoke()
        {
            var cartViewModel = cartStorage.TryGetById(userViewModel.Id)?.ToCartViewModel();
            var productCounts = cartViewModel?.Amount ?? 0;
            return View("Cart", productCounts);
        }
    }
}
