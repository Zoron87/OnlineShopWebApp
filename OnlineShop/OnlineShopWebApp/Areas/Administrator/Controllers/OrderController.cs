using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Providers;
using System;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrderStorage _orderStorage;

        public OrderController(IOrderStorage orderStorage)
        {
            _orderStorage = orderStorage;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _orderStorage.GetAllAsync();
            return View(orders.ToOrdersViewModel());
        }

        public async Task<IActionResult> DetailsAsync(Guid orderId)
        {
            var order = await _orderStorage.TryGetByIdAsync(orderId);
            return View(order.ToOrderViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatusAsync(Guid orderId, OrderStatus orderStatus)
        {
            await _orderStorage.UpdateStatusAsync(orderId, orderStatus);
            return RedirectToAction("Index");
        }
    }
}
