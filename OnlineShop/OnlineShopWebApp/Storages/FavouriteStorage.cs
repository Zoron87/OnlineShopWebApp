﻿using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
	public class FavouriteStorage : IFavouriteStorage
	{
		private readonly IProductStorage productStorage;
		private readonly List<Favourite> favourites = new List<Favourite>();

		public FavouriteStorage(IProductStorage productStorage)
		{
			this.productStorage = productStorage;
		}

		public Favourite Get(Guid userId)
		{
			return favourites.FirstOrDefault(f => f.UserId == userId);
		}

		public void Add(Guid userId, int productId)
		{
			var product = productStorage.TryGetById(productId);

			if (product == null)
				throw new Exception("Указанный товар не обнаружен!");

			var favourite = Get(userId);
			if (favourite == null)
                favourite = new Favourite(userId, new List<Product> { product});
			else
				favourite.Products.Add(product);

			favourites.Add(favourite);
        }

		public void Clear(Guid userId)
		{
            var favourite = Get(userId);

			favourite?.Products?.Clear();
		}

		public void Delete(Guid userId, int productId)
		{
            var favourite = Get(userId);
			var favouriteItem = favourite?.Products?.FirstOrDefault(p => p.Id == productId);

			if (favouriteItem != null)
				favourite?.Products?.Remove(favouriteItem);
		}
	}
}
