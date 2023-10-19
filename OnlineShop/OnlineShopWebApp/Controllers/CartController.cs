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

        public ActionResult Add(int productId, string operation="plus")
        {
            if (productId > 0)
            {
                cartStorage.AddItem(ShopUser.Id, productId, operation);
                return RedirectToAction("Index");
            }

            return View("Error");
        }

        [HttpPost]
        public ActionResult AddItems(int productId, string operation, int quantity)
        {
            if (productId > 0)
            {
                cartStorage.AddItem(ShopUser.Id, productId, operation="plus",  quantity);
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

        //public IActionResult Increase(int productId, string operation, int quantity = 1)
        //{
        //    cartStorage.AddItem(ShopUser.Id, productId, operation, quantity);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Reduce(int productId, int quantity = 1)
        //{
        //    cartStorage.Reduce(ShopUser.Id, productId, quantity);
        //    return RedirectToAction("Index");
        //}
    }
}