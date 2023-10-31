using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.Components.Compare
{
    public class CompareViewComponent : ViewComponent
    {
        private readonly ICompareStorage compareStorage;

        public CompareViewComponent(ICompareStorage compareStorage)
        {
            this.compareStorage = compareStorage;
        }

        public IViewComponentResult Invoke()
        {
            var compareProductCount = compareStorage?.TryGetById(StaticUser.Id)?.Amount;
            return View("Compare", compareProductCount);
        }
    }
}
