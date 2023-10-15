using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Views.Shared.Components.Favourite
{
    public class FavouriteViewComponent : ViewComponent
    {
        private readonly IFavouriteStorage favouriteStorage;

        public FavouriteViewComponent(IFavouriteStorage favouriteStorage)
        {
            this.favouriteStorage = favouriteStorage;
        }

        public IViewComponentResult Invoke()
        {
            var favouriteProductCount = favouriteStorage.Amount;
            return View("Favourite", favouriteProductCount);
        }

    }
}
