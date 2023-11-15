using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;

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
            var productsViewModel = productStorage.GetAll().ToProductsViewModel();
            return View(productsViewModel);
        }

        public ActionResult Edit(Guid productId)
        {
            var product = productStorage.TryGetById(productId).ToProductViewModel();
            return View(product);
        }

        public ActionResult Delete(Guid productId)
        {
            productStorage.Delete(productId);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ItemViewModel item)
        {
            if (string.IsNullOrWhiteSpace(item.ImagePath))
                item.ImagePath = "blank-product.jpg";

            if (ModelState.IsValid)
            {
                var productDb = new Product().ItemViewModelToProduct(item);
                productStorage.Add(productDb);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Save(Guid productId, ItemViewModel item)
        {
            if (string.IsNullOrWhiteSpace(item.ImagePath))
                item.ImagePath = "blank-product.jpg";

            if (ModelState.IsValid)
            {
                var product = productStorage.TryGetById(productId).ItemViewModelToProduct(item);
                productStorage.SaveChange();
                return RedirectToAction("Index");
            }
            return View(item);
        }
    }
}
