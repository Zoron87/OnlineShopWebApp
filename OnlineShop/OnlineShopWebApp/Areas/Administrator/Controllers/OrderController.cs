using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Providers;
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
            var ordersViewModel = orderStorage.GetAll().ToOrdersViewModel();
            return View(ordersViewModel);
        }

        public ActionResult Details(Guid orderId)
        {
            var orderViewModel = orderStorage.TryGetById(orderId).ToOrderViewModel();
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, OrderStatus orderStatus)
        {
            orderStorage.UpdateStatus(orderId, orderStatus);
            return RedirectToAction("Index");
        }
    }
}
