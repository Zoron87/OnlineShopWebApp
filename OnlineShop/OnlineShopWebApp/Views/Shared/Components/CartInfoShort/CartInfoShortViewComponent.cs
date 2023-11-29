using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;

namespace OnlineShopWebApp.Views.Shared.Components.CartInfoShort
{
    public class CartInfoShortViewComponent : ViewComponent
    {
        private readonly ICartStorage _cartStorage;
        private readonly UserViewModel _userViewModel;

        public CartInfoShortViewComponent(ICartStorage cartStorage, UserViewModel userViewModel)
        {
            this._cartStorage = cartStorage;
            this._userViewModel = userViewModel;
        }

        public IViewComponentResult Invoke()
        {
            var cartViewModel = _cartStorage.TryGetById(_userViewModel.Id)?.ToCartViewModel();
            return View("CartInfoShort", cartViewModel);
        }
    }
}
