using OnlineShop.DB.Interfaces;
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

		public Compare TryGetById(Guid userId)
		{
			return compares.FirstOrDefault(c => c.UserId == userId);
		}

		public void Add(Guid userId, Guid productId)
		{
			var product = productStorage.TryGetById(productId);
            var compare = TryGetById(userId);

			//if (compare == null)
			//	compare = new Compare(userId, new List<ProductViewModel> { product });
			//else
			//	compare.Products.Add(product);

			compares.Add(compare);
		}

		public void Delete(Guid userId, Guid productId)
		{
			var compare = TryGetById(userId);
			var compareItem = compare?.Products?.FirstOrDefault(p => p.Id == productId);

			if (compareItem != null)
				compare?.Products?.Remove(compareItem);
		}

		public void Clear(Guid userId)
		{
			var compare = TryGetById(userId);
			compare?.Products?.Clear();
		}
    }
}
