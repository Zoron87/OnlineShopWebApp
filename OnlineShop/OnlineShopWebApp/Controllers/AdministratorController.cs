using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IProductStorage productStorage;

        public AdministratorController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrders()
        {
            return View("GetOrders");
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
