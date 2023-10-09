using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly Cart cart;
        private readonly IOrderStorage orderStorage;

        public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage)
        {
            cart = cartStorage.TryGetById(ShopUser.Id);
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
            orderStorage.Save(orderDetails, cart, true);
            cart.Items.Clear();
            return View("Thankyou");
        }
    }
}
