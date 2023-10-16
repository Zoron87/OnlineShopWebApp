using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;

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
            var compareProductCount = compareStorage?.Amount ?? 0;
            return View("Compare", compareProductCount);
        }
    }
}
