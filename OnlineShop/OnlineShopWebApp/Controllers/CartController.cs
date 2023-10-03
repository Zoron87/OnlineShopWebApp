using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Repositories;
using OnlineShopWebApp.Storages;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        public List<CartItem> cart;
        CartStorage cartStorage = new CartStorage();
        IProductStorage productStorage = new ProductStorageInJson();
        Guid userGuid;

        public CartController()
        {
            userGuid = Guid.NewGuid();
        }

        public ActionResult Index()
        {
            var cart = cartStorage.TryGetById(userGuid);
            return View(cart);
        }

        public ActionResult Add(int productId, int quantity = 1)
        {
            if (productId > 0)
            {
                var product = productStorage.TryGetById(productId);

                var cart = cartStorage.Add(userGuid, product);
                return cart != null ? View("Index", cart) : View("Error");
            }
            else return View("Error");
        }
    }
}
