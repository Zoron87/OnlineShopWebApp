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
            var cart = cartStorage.TryGetById(StaticUser.Id);
            return View(cart);
        }

        public ActionResult Add(int productId)
        {
            cartStorage.AddItem(StaticUser.Id, productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddItems(int productId, int quantity)
        {
            if (productId > 0)
            {
                cartStorage.AddItem(StaticUser.Id, productId, quantity);
                return RedirectToAction("Index");
            }

            return View("Error");
        }

        public ActionResult Reduce(int productId)
        {
            cartStorage.Reduce(StaticUser.Id, productId);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int productId)
        {
            cartStorage.DeleteItem(StaticUser.Id, productId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            cartStorage.Clear(StaticUser.Id);
            return RedirectToAction("Index");
        }
    }
}