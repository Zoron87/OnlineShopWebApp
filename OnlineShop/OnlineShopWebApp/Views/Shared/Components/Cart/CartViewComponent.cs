using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartStorage cartStorage;
        ShopUser shopUser = new ShopUser();

        public CartViewComponent(ICartStorage cartStorage)
        {
            this.cartStorage = cartStorage;
        }
        public IViewComponentResult Invoke()
        {
            var cart = cartStorage.TryGetById(StaticUser.Id);
            var productCounts = cart?.Amount ?? 0;
            return View("Cart", productCounts);
        }
    }
}
