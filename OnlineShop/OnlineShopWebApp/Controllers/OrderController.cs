using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderStorage orderStorage;
        private ICartStorage cartStorage;

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

        public ActionResult ThankYou()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(OrderDetails orderDetails)
        {
            var cart = cartStorage.GetCart(ShopUser.Id);

            if (cart != null)
            {
                if (orderDetails != null)
                {
                    orderStorage.Save(orderDetails, cart, true);
                    cart.Items.Clear();
                    return View("ThankYou");
                }
                else
                    throw new Exception("Заполните форму оформления заказа");
            }
            else throw new Exception("Добавьте товары в корзину");
        }
    }
}
