using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private ICompareStorage compareStorage;
        private readonly ShopUser shopUser;

        public CompareController(ICompareStorage compareStorage, ShopUser shopUser)
        {
            this.compareStorage = compareStorage;
            this.shopUser = shopUser;
        }
        public ActionResult Index()
        {
            var compareProductsViewModel = compareStorage.TryGetById(shopUser.Id)?.ToCompareViewModel();
            return View(compareProductsViewModel);
        }

        public ActionResult Add(Guid productId)
        {
            compareStorage.Add(shopUser.Id, productId);
            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            compareStorage.Clear(shopUser.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid productId)
        {
            compareStorage.Delete(shopUser.Id, productId);
            return RedirectToAction("Index");
        }
    }
}
