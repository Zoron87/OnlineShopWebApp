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
        public ActionResult Index()
        {
            var orders = orderStorage.GetAll();
            return View(orders);
        }

        public ActionResult Details(Guid orderId)
        {
            var order = orderStorage.Get(orderId);
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, OrderStatus orderStatus)
        {
            orderStorage.UpdateStatus(orderId, orderStatus);
            return RedirectToAction("Index");
        }
    }
}
