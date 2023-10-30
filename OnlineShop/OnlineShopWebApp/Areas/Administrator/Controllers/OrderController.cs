using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class OrderController : Controller
    {
        private readonly IOrderStorage orderStorage;

        public OrderController(IOrderStorage orderStorage)
        {
            this.orderStorage = orderStorage;
        }
        public ActionResult GetOrders()
        {
            var orders = orderStorage.GetAll();
            return View("GetOrders", orders);
        }

        public ActionResult OrderDetails(Guid orderId)
        {
            var order = orderStorage.Get(orderId);
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus orderStatus)
        {
            orderStorage.UpdateStatus(orderId, orderStatus);
            return RedirectToAction("GetOrders");
        }
    }
}
