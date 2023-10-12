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
            var cart = cartStorage.Get(ShopUser.Id);
            return View(cart);
        }

        public ActionResult Add(int productId)
        {
            if (productId > 0)
            {
                var cart = cartStorage.AddItem(productId);
                return cart != null ? RedirectToAction("Index") : View("Error");
            }

            return View("Error");
        }

        [HttpPost]
        public ActionResult AddItems(int productId, int quantity)
        {
            if (productId > 0)
            {
                var cart = cartStorage.AddItem(productId, quantity);
                return cart != null ? RedirectToAction("Index") : View("Error");
            }

            return View("Error");
        }

        public IActionResult Delete(int productId)
        {
            var cart = cartStorage.Get(ShopUser.Id);

            if (cart != null && productId > 0)
                cart = cartStorage.DeleteItem(productId);

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            var cart = cartStorage.Get(ShopUser.Id);
            cart.Items.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Increase(int productId, int quantity = 1)
        {
            var cart = cartStorage.Increase(productId, quantity);
            return RedirectToAction("Index");
        }

        public IActionResult Reduce(int productId, int quantity = 1)
        {
            var cart = cartStorage.Reduce(productId, quantity);
            return RedirectToAction("Index");
        }
    }
}
