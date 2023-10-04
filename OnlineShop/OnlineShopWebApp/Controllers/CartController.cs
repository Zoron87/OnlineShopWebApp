﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Repositories;
using OnlineShopWebApp.Storages;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private Cart cart;
        CartStorage cartStorage = new CartStorage();
        IProductStorage productStorage = new ProductStorageInJson();

        public ActionResult Index()
        {
            cart = cartStorage.TryGetById(ShopUser.Id);
            return View(cart);
        }

        public ActionResult Add(int productId, int quantity = 1)
        {
            if (productId > 0)
            {
                var product = productStorage.TryGetById(productId);

                cart = cartStorage.Add(ShopUser.Id, product);
                return cart != null ? View("Index", cart) : View("Error");
            }

            return View("Error");
        }

        public IActionResult Delete(int productId, int quantity) 
        {
            if (productId > 0)
            {
                cart = cartStorage.TryGetById(ShopUser.Id);
                if (cart != null) 
                   cart =  cartStorage.Delete(cart, productId);
            }

            return View("Index", cart);

        }
    }
}
