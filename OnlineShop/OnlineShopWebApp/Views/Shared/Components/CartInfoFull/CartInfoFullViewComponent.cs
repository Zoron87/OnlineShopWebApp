using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;

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
            var cartViewModel = cartStorage.TryGetById(shopUser.Id)?.ToCartViewModel();
            return View("CartInfoFull", cartViewModel);
        }
    }
}
