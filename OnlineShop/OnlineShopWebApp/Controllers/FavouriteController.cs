using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavouriteController : Controller
	{
		private readonly IFavouriteStorage favouriteStorage;
        private readonly UserViewModel userViewModel;

        public FavouriteController(IFavouriteStorage favouriteStorage, UserViewModel shopUser)
        {
			this.favouriteStorage = favouriteStorage;
            this.userViewModel = shopUser;
        }
		public ActionResult Index()
		{
			var favouriteProductsViewModel = favouriteStorage.TryGetById(userViewModel.Id)?.ToFavouriteViewModel();
            return View(favouriteProductsViewModel);
        }

		public ActionResult Add(Guid productId)
		{
			favouriteStorage.Add(userViewModel.Id, productId);
			return RedirectToAction("Index");
		}

		public ActionResult Delete(Guid productId)
		{
			favouriteStorage.Delete(userViewModel.Id, productId);
			return RedirectToAction("Index");
		}

		public ActionResult Clear()
		{
			favouriteStorage.Clear(userViewModel.Id);
			return RedirectToAction("Index");
		}
	}
}
