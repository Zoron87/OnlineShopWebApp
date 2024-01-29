using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly ImageProvider _imageProvider;
        private readonly IMapper _mapper;

        public ProductController(IProductStorage productStorage, IWebHostEnvironment appEnvironent, ImageProvider imageProvider, IMapper mapper)
        {
            _productStorage = productStorage;
            _imageProvider = imageProvider;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productStorage.GetAllAsync();
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return View(productsViewModel);
        }

        public async Task<IActionResult> EditAsync(Guid productId)
        {
            var product = await _productStorage.TryGetByIdAsync(productId);
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return View(productViewModel);
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
                imagesViewModel.Add(new ImageViewModel() { URL = Constants.BlankProduct });

            item.ImagesPath = imagesViewModel;

            if (ModelState.IsValid)
            {
                var productDb = _mapper.Map<ItemViewModel, Product>(item);
                await _productStorage.AddAsync(productDb);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(Guid productId, ItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                var product = await _productStorage.TryGetByIdAsync(productId);

                if (item.UploadedFiles != null)
                    item.ImagesPath = _imageProvider.AddProductImages(item, Constants.ImageProductsFolder);

                product = _mapper.Map(item, product);
                await _productStorage.SaveChangeAsync();
                return RedirectToAction("Index");
            }
            return View("Edit", _mapper.Map<ProductViewModel>(item));
        }
    }
}
