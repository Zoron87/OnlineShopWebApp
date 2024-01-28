using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.Components.CartInfoFull
{
    public class CartInfoFullViewComponent : ViewComponent
    {
        private readonly ICartStorage _cartStorage;
        private readonly UserViewModel _userViewModel;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public CartInfoFullViewComponent(ICartStorage cartStorage, UserViewModel userViewModel, UserManager<User> userManager, IMapper mapper)
        {
            _cartStorage = cartStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(HttpContext.User)).Id) : _userViewModel.Id;
            var cart = await _cartStorage.TryGetByIdAsync(userId);
            var cartViewModel = _mapper.Map<CartViewModel>(cart); 
            return View("CartInfoFull", cartViewModel);
        }
    }
}
