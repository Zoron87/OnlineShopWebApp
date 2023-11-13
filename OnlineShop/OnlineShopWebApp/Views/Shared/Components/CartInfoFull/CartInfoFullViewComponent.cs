using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.Components.CartInfoFull
{
    public class CartInfoFullViewComponent : ViewComponent
    {
        private readonly ICartStorage cartStorage;
        private readonly ShopUser shopUser;

        public CartInfoFullViewComponent(ICartStorage cartStorage, ShopUser shopUser)
        {
            this.cartStorage = cartStorage;
            this.shopUser = shopUser;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartStorage.TryGetById(shopUser.Id);
            return View("CartInfoFull", cart);
        }
    }
}
