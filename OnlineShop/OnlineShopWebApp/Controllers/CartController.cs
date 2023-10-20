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

        public ActionResult Add(int productId, string operation)
        {
            if (productId > 0)
            {
                cartStorage.ChangeItem(ShopUser.Id, productId, operation);
                return RedirectToAction("Index");
            }

            return View("Error");
        }

        [HttpPost]
        public ActionResult AddItems(int productId, int quantity)
        {
            if (productId > 0)
            {
                cartStorage.ChangeItem(ShopUser.Id, productId, "plus", quantity);
                return RedirectToAction("Index");
            }

            return View("Error");
        }

        public IActionResult Delete(int productId)
        {
            if (productId > 0)
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