﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
	public class CartController : Controller
	{
		private Cart cart;
        private readonly ICartStorage cartStorage;

		public CartController(ICartStorage cartStorage)
		{
			this.cartStorage = cartStorage;
			cart = cartStorage.TryGetById(ShopUser.Id);
		}

		public ActionResult Index()
		{
			return View(cart);
		}

		public ActionResult Add(int productId, int quantity = 1)
		{
			if (productId > 0)
			{
				cart = cartStorage.AddItem(productId);
				return cart != null ? RedirectToAction("Index") : View("Error");
			}

			return View("Error");
		}

		public IActionResult Delete(int productId, int quantity)
		{
			if (productId > 0)
			{
				if (cart != null)
					cart = cartStorage.DeleteItem(productId);
			}

			return RedirectToAction("Index");
		}

		public IActionResult Clear()
		{
			cart.Items.Clear();
			return RedirectToAction("Index");
		}

		public IActionResult IncreaseProductCount(int productId, int quantity = 1)
		{
			cart = cartStorage.IncreaseProductCount(productId, quantity);
			return RedirectToAction("Index");
		}

		public IActionResult ReduceProductCount(int productId, int quantity = 1)
		{
			cart = cartStorage.ReduceProductCount(productId, quantity);
			return RedirectToAction("Index");
		}
    }
}
