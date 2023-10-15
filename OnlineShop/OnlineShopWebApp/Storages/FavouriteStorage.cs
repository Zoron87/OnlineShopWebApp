using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Storages
{
	public class FavouriteStorage : IFavouriteStorage
	{
		private readonly IProductStorage productStorage;
		private List<Product> favouriteProducts = new List<Product>();

		public FavouriteStorage(IProductStorage productStorage)
		{
			this.productStorage = productStorage;
		}

		public int Amount
		{
			get
			{
				return favouriteProducts.Count;
			}
		}

		public void Add(int productId)
		{
			var product = productStorage.TryGetById(productId);

			if (product != null)
				favouriteProducts.Add(product);
		}

		public void Clear()
		{
			favouriteProducts.Clear();
		}

		public void Delete(int productId)
		{
			var product = productStorage.TryGetById(productId);

			if (product != null)
				favouriteProducts.Remove(product);
		}

		public List<Product> GetAll()
		{
			return favouriteProducts;
		}
	}
}
