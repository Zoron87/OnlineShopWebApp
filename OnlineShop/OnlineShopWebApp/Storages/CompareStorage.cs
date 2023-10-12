using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Storages
{
	public class CompareStorage : ICompareStorage
	{
		private readonly IProductStorage productStorage;
		private List<Product> products = new List<Product>();

		public CompareStorage(IProductStorage productStorage)
		{
			this.productStorage = productStorage;
		}

		public List<Product> GetAll()
		{
			return products;
		}

		public void Add(int productId)
		{
			var product = productStorage.TryGetById(productId);

			if (product == null)
				throw new System.Exception("Указанный товар не найден");

			products.Add(product);
		}

		public void Delete(int productId)
		{
			var product = productStorage.TryGetById(productId);

			if (product == null)
				throw new System.Exception("Указанный товар не найден");

			products.Remove(product);
		}

		public void Clear()
		{
			products.Clear();
		}
	}
}
