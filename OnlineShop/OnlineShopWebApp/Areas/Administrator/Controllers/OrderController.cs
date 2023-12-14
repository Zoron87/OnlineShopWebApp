using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IMapper _mapper;

        public OrderController(IOrderStorage orderStorage, IMapper mapper)
        {
            _orderStorage = orderStorage;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await _orderStorage.GetAllAsync();
            var ordersViewModel = _mapper.Map<List<OrderViewModel>>(orders);
            return View(ordersViewModel);
        }

        public async Task<IActionResult> DetailsAsync(Guid orderId)
        {
            var order = await _orderStorage.TryGetByIdAsync(orderId);
            var orderViewModel = _mapper.Map<OrderViewModel>(order);
            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatusAsync(Guid orderId, OrderStatus orderStatus)
        {
            await _orderStorage.UpdateStatusAsync(orderId, orderStatus);
            return RedirectToAction("Index");
        }
    }
}
