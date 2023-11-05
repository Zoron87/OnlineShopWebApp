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
        public ActionResult Index()
        {
            var products = productStorage.GetAll();
            return View(products);
        }

        public ActionResult Edit(int productId)
        {
            var product = productStorage.TryGetById(productId);
            return View(product);
        }

        public ActionResult Delete(int productId)
        {
            productStorage.Delete(productId);
            if (productStorage.SaveAll())
                return RedirectToAction("Index");
            return View("Error");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Item item)
        {
            if (string.IsNullOrWhiteSpace(item.ImagePath))
                item.ImagePath = "blank-product.jpg";

            if (ModelState.IsValid)
            {
                productStorage.Add(item);
                if (productStorage.SaveAll())
                    return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Save(int productId, Item item)
        {
            if (string.IsNullOrWhiteSpace(item.ImagePath))
                item.ImagePath = "blank-product.jpg";

            if (ModelState.IsValid)
            {
                productStorage.SaveChange(productId, item);
                if (productStorage.SaveAll())
                    return RedirectToAction("Index");
            }
            return View(item);
        }
    }
}
