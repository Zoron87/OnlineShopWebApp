using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IProductStorage productStorage;
		private readonly IOrderStorage orderStorage;

		public AdministratorController(IProductStorage productStorage, IOrderStorage orderStorage)
        {
            this.productStorage = productStorage;
			this.orderStorage = orderStorage;
		}
        public ActionResult Index()
        {
            return View();
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

		public ActionResult GetUsers()
        {
            return View("GetUsers");
        }

        public ActionResult GetRoles()
        {
            return View("GetRoles");
        }

        public ActionResult GetProducts()
        {
            var products = productStorage.GetAll();
            return View(products);
        }

        public ActionResult EditProduct(int productId)
        {
            var product = productStorage.TryGetById(productId);
            return View("EditProduct", product);
        }

        public ActionResult DeleteProduct(int productId)
        {
            productStorage.Delete(productId);
            if (productStorage.SaveAll())
                return RedirectToAction("GetProducts");
            return View("Error");
        }

        public ActionResult AddProduct()
        {
            return View("AddProduct");
        }

        [HttpPost]
        public ActionResult AddProduct(Item item)
        {
            if (ModelState.IsValid)
            {
                productStorage.Add(item);
                if (productStorage.SaveAll())
                    return RedirectToAction("GetProducts");
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult SaveProduct(int productId, Item item)
        {
            if (ModelState.IsValid)
            {
                productStorage.SaveChange(productId, item);
                if (productStorage.SaveAll())
                    return RedirectToAction("GetProducts");
            }
            return View(item);
        }
    }
}
