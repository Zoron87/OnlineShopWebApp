using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartStorage cartStorage;
        private readonly UserViewModel userViewModel;

        public CartController(ICartStorage cartStorage, UserViewModel userViewModel)
        {
            this.cartStorage = cartStorage;
            this.userViewModel = userViewModel;
        }

        public ActionResult Index()
        {
            var cartViewModel = cartStorage.TryGetById(userViewModel.Id)?.ToCartViewModel();
            return View(cartViewModel);
        }

        public ActionResult Add(Guid productId)
        {
            cartStorage.AddItem(userViewModel.Id, productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddItems(Guid productId, int quantity)
        {
            cartStorage.AddItem(userViewModel.Id, productId, quantity);
            return RedirectToAction("Index");
        }

        public ActionResult Reduce(Guid productId)
        {
            cartStorage.Reduce(userViewModel.Id, productId);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid productId)
        {
            cartStorage.DeleteItem(userViewModel.Id, productId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            cartStorage.Clear(userViewModel.Id);
            return RedirectToAction("Index");
        }
    }
}