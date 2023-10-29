using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IProductStorage productStorage;
		private readonly IOrderStorage orderStorage;
        private readonly IRoleStorage roleStorage;

        public AdministratorController(IProductStorage productStorage, IOrderStorage orderStorage, IRoleStorage roleStorage)
        {
            this.productStorage = productStorage;
			this.orderStorage = orderStorage;
            this.roleStorage = roleStorage;
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
            return View();
        }

        public ActionResult GetRoles()
        {
            var roles = roleStorage.GetAll();
            return View(roles);
        }

        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(Role role)
        {
            var roles = roleStorage.GetAll();
            if (roles.Any(r => r.Name.ToLower() == role.Name.ToLower()))
            {
                ModelState.AddModelError("Name", $"Роль {role.Name} уже существует");
            }

            if (ModelState.IsValid)
            {
                roleStorage.Add(role);
                return RedirectToAction("GetRoles");
            }
            return View(role);
        }

        public ActionResult DeleteRole(string name)
        {
            roleStorage.Delete(name);
            return RedirectToAction("GetRoles");
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
            if (string.IsNullOrWhiteSpace(item.ImagePath))
                item.ImagePath = "blank-product.jpg";

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
            if (string.IsNullOrWhiteSpace(item.ImagePath))
                item.ImagePath = "blank-product.jpg";

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
