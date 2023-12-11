using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var productsViewModel = (await _productStorage.GetAllAsync()).ToProductsViewModel();
            return View(productsViewModel);
        }

        public async Task<IActionResult> EditAsync(Guid productId)
        {
            var product = (await _productStorage.TryGetByIdAsync(productId)).ToProductViewModel();
            return View(product);
        }

        public async Task<IActionResult> DeleteAsync(Guid productId)
        {
            await _productStorage.DeleteAsync(productId);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAsync(ItemViewModel item)
        {
            var imagesViewModel = _imageProvider.AddProductImages(item, Constants.ImageProductsFolder);

            if (imagesViewModel.Count == 0)
                imagesViewModel.Add(new ImageViewModel() { URL = Constants.ImageProductsFolder + Constants.BlankAvatar });

            item.ImagesPath = imagesViewModel;

            if (ModelState.IsValid)
            {
                var productDb = new Product().ItemViewModelToProduct(item);
                await _productStorage.AddAsync(productDb);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(Guid productId, ItemViewModel item)
        {
            item.ImagesPath = _imageProvider.AddProductImages(item, Constants.ImageProductsFolder);

            if (ModelState.IsValid)
            {
                var product = (await _productStorage.TryGetByIdAsync(productId)).ItemViewModelToProduct(item);
                await _productStorage.SaveChangeAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }
    }
}
