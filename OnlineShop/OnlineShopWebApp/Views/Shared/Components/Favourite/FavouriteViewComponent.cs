using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;

namespace OnlineShopWebApp.Views.Shared.Components.Favourite
{
    public class FavouriteViewComponent : ViewComponent
    {
        private readonly IFavouriteStorage favouriteStorage;
        private readonly UserViewModel userViewModel;

        public FavouriteViewComponent(IFavouriteStorage favouriteStorage, UserViewModel shopUser)
        {
            this.favouriteStorage = favouriteStorage;
            this.userViewModel = shopUser;
        }

        public IViewComponentResult Invoke()
        {
            var favouriteProductsViewModel = favouriteStorage.TryGetById(userViewModel.Id)?.ToFavouriteViewModel();
            return View("Favourite", favouriteProductsViewModel?.Amount ?? 0);
        }
    }
}
