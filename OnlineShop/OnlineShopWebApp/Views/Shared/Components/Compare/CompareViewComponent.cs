using AutoMapper;
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
        private readonly IMapper _mapper;

        public CompareViewComponent(ICompareStorage compareStorage, UserViewModel userViewModel, UserManager<User> userManager, IMapper mapper)
        {
            _compareStorage = compareStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse((await _userManager.GetUserAsync(HttpContext.User)).Id) : _userViewModel.Id;
            var compareProduct = await _compareStorage?.TryGetByIdAsync(userId);
            var compareProductViewModel = _mapper.Map<CompareViewModel>(compareProduct);
            return View("Compare", compareProductViewModel?.Amount ?? 0);
        }
                
    }
}
