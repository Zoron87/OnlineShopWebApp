using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
    public class CompareStorage : ICompareStorage
	{
		private readonly DatabaseContext databaseContext;

        public CompareStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Compare TryGetById(Guid userId)
		{
			return databaseContext.Compares.Include(el => el.Products).FirstOrDefault(c => c.UserId == userId);
		}

		public void Add(Guid userId, Guid productId)
		{
			var product = databaseContext.Products.FirstOrDefault(el => el.Id == productId);
            var compare = TryGetById(userId);

			if (compare == null)
			{
				compare = new Compare() { UserId = userId, Products = new List<Product> { product } };
                databaseContext.Compares.Add(compare);
            }
			else
				compare.Products.Add(product);

			databaseContext.SaveChanges();
        }

		public void Delete(Guid userId, Guid productId)
		{
			var compare = TryGetById(userId);
			var compareItem = compare?.Products?.FirstOrDefault(p => p.Id == productId);

			if (compareItem != null)
				compare?.Products?.Remove(compareItem);
			databaseContext.SaveChanges();
		}

		public void Clear(Guid userId)
		{
			var compare = TryGetById(userId);
			compare?.Products?.Clear();
			databaseContext.SaveChanges();
		}
    }
}
