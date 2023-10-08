using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	public class CartController : Controller
    {
        private Cart cart;
		private readonly ICartStorage cartStorage;

		public CartController(ICartStorage cartStorage)
        {
            this.cartStorage = cartStorage;
        }

        public ActionResult Index()
        {
            cart = cartStorage.TryGetById(ShopUser.Id);
            return View(cart);
        }

        public ActionResult Add(int productId, int quantity = 1)
        {
            if (productId > 0)
            {
                cart = cartStorage.Add(ShopUser.Id, productId);
                return cart != null ? RedirectToAction("Index") : View("Error");
            }

            return View("Error");
        }

        public IActionResult Delete(int productId, int quantity)
        {
            if (productId > 0)
            {
                cart = cartStorage.TryGetById(ShopUser.Id);
                if (cart != null)
                    cart = cartStorage.Delete(cart, productId);
            }

            return RedirectToAction("Index");
        }
    }
}
