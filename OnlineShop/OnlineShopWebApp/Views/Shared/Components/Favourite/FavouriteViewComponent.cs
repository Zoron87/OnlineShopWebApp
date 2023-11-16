using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;

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
            var favouriteProductsViewModel = favouriteStorage.TryGetById(shopUser.Id)?.ToFavouriteViewModel();
            return View("Favourite", favouriteProductsViewModel?.Amount ?? 0);
        }
    }
}
