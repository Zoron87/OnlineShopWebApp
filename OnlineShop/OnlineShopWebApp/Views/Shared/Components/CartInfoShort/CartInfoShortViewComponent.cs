using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.Components.CartInfoShort
{
    public class CartInfoShortViewComponent : ViewComponent
    {
        private readonly ICartStorage cartStorage;
        private readonly ShopUser shopUser;

        public CartInfoShortViewComponent(ICartStorage cartStorage, ShopUser shopUser)
        {
            this.cartStorage = cartStorage;
            this.shopUser = shopUser;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartStorage.TryGetById(shopUser.Id);
            return View("CartInfoShort", cart);
        }
    }
}
