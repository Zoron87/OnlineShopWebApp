using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartStorage cartStorage;
        private readonly IOrderStorage orderStorage;

        public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage)
        {
            this.cartStorage = cartStorage;
            this.orderStorage = orderStorage;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Thankyou()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(OrderDetails orderDetails)
        {
            var cart = cartStorage.GetCart(ShopUser.Id);

            orderStorage.Save(orderDetails, cart, true);

            cart.Items.Clear();

            return View("Thankyou");
        }
    }
}
