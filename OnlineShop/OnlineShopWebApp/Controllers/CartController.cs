using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

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
            var cart = cartStorage.TryGetById(shopUser.Id);
            return View(cart);
        }

        public ActionResult Add(int productId)
        {
            cartStorage.AddItem(shopUser.Id, productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddItems(int productId, int quantity)
        {
            if (productId > 0)
            {
                cartStorage.AddItem(shopUser.Id, productId, quantity);
                return RedirectToAction("Index");
            }

            return View("Error");
        }

        public ActionResult Reduce(int productId)
        {
            cartStorage.Reduce(shopUser.Id, productId);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int productId)
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