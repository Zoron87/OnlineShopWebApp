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
        private readonly ShopUser shopUser;

        public CompareViewComponent(ICompareStorage compareStorage, ShopUser shopUser)
        {
            this.compareStorage = compareStorage;
            this.shopUser = shopUser;
        }

        public IViewComponentResult Invoke()
        {
            var compareProductViewModel = compareStorage?.TryGetById(shopUser.Id)?.ToCompareViewModel();
            return View("Compare", compareProductViewModel?.Amount ?? 0);
        }
                
    }
}
