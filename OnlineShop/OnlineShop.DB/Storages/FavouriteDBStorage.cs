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
        private readonly DatabaseContext _databaseContext;

        public FavouriteStorage(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public Favourite TryGetById(Guid userId)
		{
			return _databaseContext.Favourites.Include(el => el.Products).FirstOrDefault(f => f.UserId == userId);
		}

		public void Add(Guid userId, Guid productId)
		{
			var product = _databaseContext.Products.FirstOrDefault(el => el.Id == productId);

			if (product == null) throw new Exception("Указанный товар не обнаружен!");

			var favourite = TryGetById(userId);
			if (favourite == null)
			{
				favourite = new Favourite() { UserId = userId, Products = new List<Product> { product } };
                _databaseContext.Favourites.Add(favourite);
            }
			else
				favourite.Products.Add(product);
            
            _databaseContext.SaveChanges();
        }

		public void Clear(Guid userId)
		{
            var favourite = TryGetById(userId);
			_databaseContext.Favourites.Remove(favourite);
			_databaseContext.SaveChanges() ;
		}

		public void Delete(Guid userId, Guid productId)
		{
            var favourite = TryGetById(userId);
			var favouriteItem = _databaseContext?.Products?.FirstOrDefault(p => p.Id == productId);

			if (favouriteItem != null)
				favourite?.Products?.Remove(favouriteItem);
			_databaseContext.SaveChanges() ;
		}
	}
}
