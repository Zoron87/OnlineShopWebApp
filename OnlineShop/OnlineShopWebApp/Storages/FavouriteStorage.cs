using OnlineShopWebApp.Interfaces;
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
		//private List<Product> favouriteProducts = new List<Product>();

		public FavouriteStorage(IProductStorage productStorage)
		{
			this.productStorage = productStorage;
		}

		public Favourite Get(Guid userId)
		{
			return favourites.FirstOrDefault(f => f.UserId == userId);
		}

		public void Add(int productId)
		{
			var product = productStorage.TryGetById(productId);

			if (product == null)
				throw new Exception("Указанный товар не обнаружен!");

			var favourite = Get(ShopUser.Id);
			if (favourite == null)
                favourite = new Favourite(ShopUser.Id, new List<Product> { product});
			else
				favourite.Products.Add(product);

			favourites.Add(favourite);
        }

		public void Clear(Guid userId)
		{
            //favourites.Products.Clear();
            var favourite = Get(ShopUser.Id);
            favourite.Products.Clear();
		}

		public void Delete(int productId)
		{
            var favourite = Get(ShopUser.Id);
			var favouriteItem = favourite?.Products?.FirstOrDefault(p => p.Id == productId);

			if (favouriteItem != null)
				favourite.Products.Remove(favouriteItem);
				//favourite.Products.Remove(product);
		}

		//public List<Favourite> GetAll()
		//{
		//	return favourites;
		//}
	}
}
