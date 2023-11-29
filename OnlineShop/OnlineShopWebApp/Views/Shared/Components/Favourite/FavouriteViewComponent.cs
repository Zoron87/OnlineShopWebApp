using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;

namespace OnlineShopWebApp.Views.Shared.Components.Favourite
{
    public class FavouriteViewComponent : ViewComponent
    {
        private readonly IFavouriteStorage _favouriteStorage;
        private readonly UserViewModel _userViewModel;

        public FavouriteViewComponent(IFavouriteStorage favouriteStorage, UserViewModel userViewModel)
        {
            this._favouriteStorage = favouriteStorage;
            this._userViewModel = userViewModel;
        }

        public IViewComponentResult Invoke()
        {
            var favouriteProductsViewModel = _favouriteStorage.TryGetById(_userViewModel.Id)?.ToFavouriteViewModel();
            return View("Favourite", favouriteProductsViewModel?.Amount ?? 0);
        }
    }
}
