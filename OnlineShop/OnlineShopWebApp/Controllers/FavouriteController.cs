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
    public class FavouriteController : Controller
	{
		private readonly IFavouriteStorage _favouriteStorage;
        private readonly UserViewModel _userViewModel;

        public FavouriteController(IFavouriteStorage favouriteStorage, UserViewModel userViewModel)
        {
			this._favouriteStorage = favouriteStorage;
            this._userViewModel = userViewModel;
        }
		public ActionResult Index()
		{
			var favouriteProductsViewModel = _favouriteStorage.TryGetById(_userViewModel.Id)?.ToFavouriteViewModel();
            return View(favouriteProductsViewModel);
        }

		public ActionResult Add(Guid productId)
		{
			_favouriteStorage.Add(_userViewModel.Id, productId);
			return RedirectToAction("Index");
		}

		public ActionResult Delete(Guid productId)
		{
			_favouriteStorage.Delete(_userViewModel.Id, productId);
			return RedirectToAction("Index");
		}

		public ActionResult Clear()
		{
			_favouriteStorage.Clear(_userViewModel.Id);
			return RedirectToAction("Index");
		}
	}
}
