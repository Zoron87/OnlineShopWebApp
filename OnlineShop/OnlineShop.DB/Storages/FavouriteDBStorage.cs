using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
    public class FavouriteStorage : IFavouriteStorage
	{
        private readonly DatabaseContext databaseContext;

        public FavouriteStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Favourite TryGetById(Guid userId)
		{
			return databaseContext.Favourites.Include(el => el.Products).FirstOrDefault(f => f.UserId == userId);
		}

		public void Add(Guid userId, Guid productId)
		{
			var product = databaseContext.Products.FirstOrDefault(el => el.Id == productId);

			if (product == null) throw new Exception("Указанный товар не обнаружен!");

			var favourite = TryGetById(userId);
			if (favourite == null)
			{
				favourite = new Favourite() { UserId = userId, Products = new List<Product> { product } };
                databaseContext.Favourites.Add(favourite);
            }
			else
				favourite.Products.Add(product);
            
            databaseContext.SaveChanges();
        }

		public void Clear(Guid userId)
		{
            var favourite = TryGetById(userId);
			databaseContext.Favourites.Remove(favourite);
			databaseContext.SaveChanges() ;
		}

		public void Delete(Guid userId, Guid productId)
		{
            var favourite = TryGetById(userId);
			var favouriteItem = databaseContext?.Products?.FirstOrDefault(p => p.Id == productId);

			if (favouriteItem != null)
				favourite?.Products?.Remove(favouriteItem);
			databaseContext.SaveChanges() ;
		}
	}
}
