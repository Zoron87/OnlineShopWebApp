using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;

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
            var cartViewModel = cartStorage.TryGetById(shopUser.Id)?.ToCartViewModel();
            return View("CartInfoShort", cartViewModel);
        }
    }
}
