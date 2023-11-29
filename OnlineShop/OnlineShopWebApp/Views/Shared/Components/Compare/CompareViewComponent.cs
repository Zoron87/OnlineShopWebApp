using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System.Collections.Generic;

namespace OnlineShopWebApp.Views.Shared.Components.Compare
{
    public class CompareViewComponent : ViewComponent
    {
        private readonly ICompareStorage _compareStorage;
        private readonly UserViewModel _userViewModel;

        public CompareViewComponent(ICompareStorage compareStorage, UserViewModel userViewModel)
        {
            this._compareStorage = compareStorage;
            this._userViewModel = userViewModel;
        }

        public IViewComponentResult Invoke()
        {
            var compareProductViewModel = _compareStorage?.TryGetById(_userViewModel.Id)?.ToCompareViewModel();
            return View("Compare", compareProductViewModel?.Amount ?? 0);
        }
                
    }
}
