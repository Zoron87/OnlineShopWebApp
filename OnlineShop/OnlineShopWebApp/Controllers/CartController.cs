﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;

namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartStorage _cartStorage;
        private readonly UserViewModel _userViewModel;
        private readonly UserManager<User> _userManager;

        public CartController(ICartStorage cartStorage, UserViewModel userViewModel, UserManager<User> userManager)
        {
            _cartStorage = cartStorage;
            _userViewModel = userViewModel;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.IsAuthenticated ? _userManager.GetUserAsync(User).Result.Id : _userViewModel.Id.ToString();
            var cartViewModel = _cartStorage.TryGetById(userId)?.ToCartViewModel();
            return View(cartViewModel);
        }

        public ActionResult Add(Guid productId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            _cartStorage.AddItem(Guid.Parse(user.Id), productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddItems(Guid productId, int quantity)
        {
            var user = _userManager.GetUserAsync(User).Result;
            _cartStorage.AddItem(Guid.Parse(user.Id), productId, quantity);
            return RedirectToAction("Index");
        }

        public ActionResult Reduce(Guid productId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            _cartStorage.Reduce(Guid.Parse(user.Id), productId);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid productId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            _cartStorage.DeleteItem(Guid.Parse(user.Id), productId);
            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            var user = _userManager.GetUserAsync(User).Result;
            _cartStorage.Clear(Guid.Parse(user.Id));
            return RedirectToAction("Index");
        }
    }
}