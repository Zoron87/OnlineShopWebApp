using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly ImageProvider _imageProvider;

        public ProductController(IProductStorage productStorage, IWebHostEnvironment appEnvironent, ImageProvider imageProvider)
        {
            _productStorage = productStorage;
            _imageProvider = imageProvider;
        }
        public ActionResult Index()
        {
            var productsViewModel = _productStorage.GetAll().ToProductsViewModel();
            return View(productsViewModel);
        }

        public ActionResult Edit(Guid productId)
        {
            var product = _productStorage.TryGetById(productId).ToProductViewModel();
            return View(product);
        }

        public ActionResult Delete(Guid productId)
        {
            _productStorage.Delete(productId);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ItemViewModel item)
        {
            var imagesViewModel = _imageProvider.AddProductImages(item, Constants.ImageProductsFolder);

            if (imagesViewModel.Count == 0)
                imagesViewModel.Add(new ImageViewModel() { URL = Constants.ImageProductsFolder + Constants.BlankAvatar });

            item.ImagesPath = imagesViewModel;

            if (ModelState.IsValid)
            {
                var productDb = new Product().ItemViewModelToProduct(item);
                _productStorage.Add(productDb);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Save(Guid productId, ItemViewModel item)
        {
            item.ImagesPath = _imageProvider.AddProductImages(item, Constants.ImageProductsFolder);

            if (ModelState.IsValid)
            {
                var product = _productStorage.TryGetById(productId).ItemViewModelToProduct(item);
                _productStorage.SaveChange();
                return RedirectToAction("Index");
            }
            return View(item);
        }
    }
}
