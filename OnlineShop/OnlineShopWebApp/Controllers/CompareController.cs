using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
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
            var products = compareStorage.TryGetById(shopUser.Id);
            return View(products);
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
