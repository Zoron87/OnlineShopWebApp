using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        private readonly ICompareStorage _compareStorage;
        private readonly UserViewModel _userViewModel;

        public CompareController(ICompareStorage compareStorage, UserViewModel userViewModel)
        {
            this._compareStorage = compareStorage;
            this._userViewModel = userViewModel;
        }
        public ActionResult Index()
        {
            var compareProductsViewModel = _compareStorage.TryGetById(_userViewModel.Id)?.ToCompareViewModel();
            return View(compareProductsViewModel);
        }

        public ActionResult Add(Guid productId)
        {
            _compareStorage.Add(_userViewModel.Id, productId);
            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            _compareStorage.Clear(_userViewModel.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid productId)
        {
            _compareStorage.Delete(_userViewModel.Id, productId);
            return RedirectToAction("Index");
        }
    }
}
