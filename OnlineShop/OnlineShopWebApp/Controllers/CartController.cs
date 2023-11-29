using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartStorage _cartStorage;
        private readonly UserViewModel _userViewModel;

        public CartController(ICartStorage cartStorage, UserViewModel userViewModel)
        {
            this._cartStorage = cartStorage;
            this._userViewModel = userViewModel;
        }

        public ActionResult Index()
        {
            var cartViewModel = _cartStorage.TryGetById(_userViewModel.Id)?.ToCartViewModel();
            return View(cartViewModel);
        }

        public ActionResult Add(Guid productId)
        {
            _cartStorage.AddItem(_userViewModel.Id, productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddItems(Guid productId, int quantity)
        {
            _cartStorage.AddItem(_userViewModel.Id, productId, quantity);
            return RedirectToAction("Index");
        }

        public ActionResult Reduce(Guid productId)
        {
            _cartStorage.Reduce(_userViewModel.Id, productId);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid productId)
        {
            _cartStorage.DeleteItem(_userViewModel.Id, productId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            _cartStorage.Clear(_userViewModel.Id);
            return RedirectToAction("Index");
        }
    }
}