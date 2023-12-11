using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Views.Shared.Components.Compare
{
    public class CompareViewComponent : ViewComponent
    {
        private readonly ICompareStorage _compareStorage;
        private readonly UserViewModel _userViewModel;
        private readonly UserManager<User> _userManager;

        public CompareViewComponent(ICompareStorage compareStorage, UserViewModel userViewModel, UserManager<User> userManager)
        {
            _compareStorage = compareStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User)).Id) : _userViewModel.Id;
            var compareProductViewModel = (await _compareStorage?.TryGetByIdAsync(userId))?.ToCompareViewModel();
            return View("Compare", compareProductViewModel?.Amount ?? 0);
        }
                
    }
}
