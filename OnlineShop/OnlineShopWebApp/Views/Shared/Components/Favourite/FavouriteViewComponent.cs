using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.Components.Favourite
{
    public class FavouriteViewComponent : ViewComponent
    {
        private readonly IFavouriteStorage _favouriteStorage;
        private readonly UserViewModel _userViewModel;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public FavouriteViewComponent(IFavouriteStorage favouriteStorage, UserViewModel userViewModel, UserManager<User> userManager, IMapper mapper)
        {
            _favouriteStorage = favouriteStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(HttpContext.User)).Id) : _userViewModel.Id;
            var favouriteProducts = await _favouriteStorage.TryGetByIdAsync(userId);
            var favouriteProductsViewModel = _mapper.Map<FavouriteViewModel>(favouriteProducts);
            return View("Favourite", favouriteProductsViewModel?.Amount ?? 0);
        }
    }
}
