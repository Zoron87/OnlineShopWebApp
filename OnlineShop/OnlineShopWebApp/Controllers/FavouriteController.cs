using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
	public class FavouriteController : Controller
	{
		private readonly IFavouriteStorage favouriteStorage;
        private readonly ShopUser shopUser;

        public FavouriteController(IFavouriteStorage favouriteStorage, ShopUser shopUser)
        {
			this.favouriteStorage = favouriteStorage;
            this.shopUser = shopUser;
        }
		public ActionResult Index()
		{
			var favouriteProductsViewModel = favouriteStorage.TryGetById(shopUser.Id)?.ToFavouriteViewModel();
            return View(favouriteProductsViewModel);
        }

		public ActionResult Add(Guid productId)
		{
			favouriteStorage.Add(shopUser.Id, productId);
			return RedirectToAction("Index");
		}

		public ActionResult Delete(Guid productId)
		{
			favouriteStorage.Delete(shopUser.Id, productId);
			return RedirectToAction("Index");
		}

		public ActionResult Clear()
		{
			favouriteStorage.Clear(shopUser.Id);
			return RedirectToAction("Index");
		}
	}
}
