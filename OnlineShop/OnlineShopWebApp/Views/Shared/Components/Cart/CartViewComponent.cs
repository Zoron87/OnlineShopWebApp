using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartStorage cartStorage;

        public CartViewComponent(ICartStorage cartStorage)
        {
            this.cartStorage = cartStorage;
        }
        public IViewComponentResult Invoke()
        {
            var cart = cartStorage.Get(ShopUser.Id);
            var productCounts = cart?.Amount ?? 0;
            return View("Cart", productCounts);
        }
    }
}
