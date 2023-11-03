using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

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
            var compareProductCount = compareStorage?.TryGetById(shopUser.Id)?.Amount;
            return View("Compare", compareProductCount);
        }
    }
}
