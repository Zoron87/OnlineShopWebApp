using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CompareController : Controller
    {
        private ICompareStorage compareStorage;
        private readonly UserViewModel userViewModel;

        public CompareController(ICompareStorage compareStorage, UserViewModel shopUser)
        {
            this.compareStorage = compareStorage;
            this.userViewModel = shopUser;
        }
        public ActionResult Index()
        {
            var compareProductsViewModel = compareStorage.TryGetById(userViewModel.Id)?.ToCompareViewModel();
            return View(compareProductsViewModel);
        }

        public ActionResult Add(Guid productId)
        {
            compareStorage.Add(userViewModel.Id, productId);
            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            compareStorage.Clear(userViewModel.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid productId)
        {
            compareStorage.Delete(userViewModel.Id, productId);
            return RedirectToAction("Index");
        }
    }
}
