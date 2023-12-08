using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Views.Shared.Components.Avatar
{
    public class AvatarViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly UserViewModel _userViewModel;

        public AvatarViewComponent(UserManager<User> userManager, UserViewModel userViewModel)
        {
            _userManager = userManager;
            _userViewModel = userViewModel;
        }
        public IViewComponentResult Invoke()
        {
            var userId = User.Identity.IsAuthenticated ? _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User).Result.Id : _userViewModel.Id.ToString();
            var user = _userManager.FindByIdAsync(userId).Result;
            return View("Avatar", user?.AvatarImagepath ?? "");
         }
    }
}
