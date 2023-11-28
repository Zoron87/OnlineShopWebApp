using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System.Collections.Generic;

namespace OnlineShopWebApp.Views.Shared.Components.Compare
{
    public class CompareViewComponent : ViewComponent
    {
        private readonly ICompareStorage compareStorage;
        private readonly UserViewModel userViewModel;

        public CompareViewComponent(ICompareStorage compareStorage, UserViewModel shopUser)
        {
            this.compareStorage = compareStorage;
            this.userViewModel = shopUser;
        }

        public IViewComponentResult Invoke()
        {
            var compareProductViewModel = compareStorage?.TryGetById(userViewModel.Id)?.ToCompareViewModel();
            return View("Compare", compareProductViewModel?.Amount ?? 0);
        }
                
    }
}
