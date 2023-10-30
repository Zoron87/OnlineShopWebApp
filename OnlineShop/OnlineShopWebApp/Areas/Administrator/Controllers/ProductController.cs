using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProductController : Controller
    {
        private readonly IProductStorage productStorage;

        public ProductController(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
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
