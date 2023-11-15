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
        private readonly ShopUser shopUser;

        public CartViewComponent(ICartStorage cartStorage, ShopUser shopUser)
        {
            this.cartStorage = cartStorage;
            this.shopUser = shopUser;
        }
        public IViewComponentResult Invoke()
        {
            var cartViewModel = cartStorage.TryGetById(shopUser.Id)?.ToCartViewModel();
            var productCounts = cartViewModel?.Amount ?? 0;
            return View("Cart", productCounts);
        }
    }
}
