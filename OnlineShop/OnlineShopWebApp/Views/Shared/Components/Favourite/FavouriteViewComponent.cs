using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.Components.Favourite
{
    public class FavouriteViewComponent : ViewComponent
    {
        private readonly IFavouriteStorage favouriteStorage;
        private readonly ShopUser shopUser;

        public FavouriteViewComponent(IFavouriteStorage favouriteStorage, ShopUser shopUser)
        {
            this.favouriteStorage = favouriteStorage;
            this.shopUser = shopUser;
        }

        public IViewComponentResult Invoke()
        {
            var favouriteProductCount = favouriteStorage?.TryGetById(shopUser.Id)?.Amount;
            return View("Favourite", favouriteProductCount);
        }
    }
}
