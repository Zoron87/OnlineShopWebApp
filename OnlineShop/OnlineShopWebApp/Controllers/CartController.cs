using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartStorage cartStorage;
        private readonly ShopUser shopUser;

        public CartController(ICartStorage cartStorage, ShopUser shopUser)
        {
            this.cartStorage = cartStorage;
            this.shopUser = shopUser;
        }

        public ActionResult Index()
        {
            var cartViewModel = cartStorage.TryGetById(shopUser.Id)?.ToCartViewModel();
            return View(cartViewModel);
        }

        public ActionResult Add(Guid productId)
        {
            cartStorage.AddItem(shopUser.Id, productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddItems(Guid productId, int quantity)
        {
            cartStorage.AddItem(shopUser.Id, productId, quantity);
            return RedirectToAction("Index");
        }

        public ActionResult Reduce(Guid productId)
        {
            cartStorage.Reduce(shopUser.Id, productId);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid productId)
        {
            cartStorage.DeleteItem(shopUser.Id, productId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            cartStorage.Clear(shopUser.Id);
            return RedirectToAction("Index");
        }
    }
}