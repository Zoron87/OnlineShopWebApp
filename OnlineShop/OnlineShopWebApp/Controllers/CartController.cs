using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartStorage cartStorage;

        public CartController(ICartStorage cartStorage)
        {
            this.cartStorage = cartStorage;
        }

        public ActionResult Index()
        {
            var cart = cartStorage.TryGetById(ShopUser.Id);
            return View(cart);
        }

        public ActionResult Add(int productId)
        {
            cartStorage.AddItem(ShopUser.Id, productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddItems(int productId, int quantity)
        {
            if (productId > 0)
            {
                cartStorage.AddItem(ShopUser.Id, productId, quantity);
                return RedirectToAction("Index");
            }

            return View("Error");
        }

        public ActionResult Reduce(int productId)
        {
            cartStorage.Reduce(ShopUser.Id, productId);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int productId)
        {
            cartStorage.DeleteItem(ShopUser.Id, productId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            cartStorage.Clear(ShopUser.Id);
            return RedirectToAction("Index");
        }
    }
}