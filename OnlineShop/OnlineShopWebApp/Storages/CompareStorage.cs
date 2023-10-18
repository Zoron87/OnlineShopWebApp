using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
	public class CompareStorage : ICompareStorage
	{
		private readonly IProductStorage productStorage;
		private List<Compare> compares = new List<Compare>();

		public CompareStorage(IProductStorage productStorage)
		{
			this.productStorage = productStorage;
		}

		public Compare Get(Guid userId)
		{
			return compares.FirstOrDefault(c => c.UserId == userId);
		}

		public void Add(int productId)
		{
			var product = productStorage.TryGetById(productId);

            CheckExistProduct(product);

            var compare = Get(ShopUser.Id);

			if (compare == null)
				compare = new Compare(ShopUser.Id, new List<Product> { product });
			else
				compare.Products.Add(product);

			compares.Add(compare);
		}

		public void Delete(int productId)
		{
			var compare = Get(ShopUser.Id);
			var compareItem = compare?.Products?.FirstOrDefault(p => p.Id == productId);

			if (compareItem != null)
				compare?.Products?.Remove(compareItem);
		}

		public void Clear(Guid userId)
		{
			var compare = Get(userId);

			compare?.Products?.Clear();
		}

		private void CheckExistProduct(Product product)
		{
			if (product == null)
				throw new Exception("Указанный товар не обнаружен!");
		}
	}
}
