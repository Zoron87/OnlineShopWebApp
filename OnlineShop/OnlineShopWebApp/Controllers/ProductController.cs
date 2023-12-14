using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductStorage _productStorage;
        private readonly IMapper _mapper;

        public ProductController(IProductStorage productStorage, IMapper mapper = null)
        {
            _productStorage = productStorage;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(Guid productId)
        {
            var product = await _productStorage.TryGetByIdAsync(productId);
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return productViewModel != null ? View(productViewModel) : View("Error");
        }

        public async Task<IActionResult> ViewAsync(int page = 1, int itemsOnPage = 1)
        {
            var products = (await _productStorage.GetProductsWithPaginationAsync(page, itemsOnPage));
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return products != null ? View(products) : View("Error");
        }

        public async Task<IActionResult> SearchAsync(string search) 
        {
            ViewData["Search"] = search;
            search = search.ToLower();
            var products = (await _productStorage.GetAllAsync()).Where(p => p.Name.ToLower().Contains(search) || p.Description.ToLower().Contains(search)).ToList();
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return View(productsViewModel);
        }
    }
}