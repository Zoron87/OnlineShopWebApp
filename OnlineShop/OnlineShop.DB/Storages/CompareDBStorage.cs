using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Storages
{
    public class CompareStorage : ICompareStorage
	{
		private readonly DatabaseContext _databaseContext;

        public CompareStorage(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public async Task<Compare> TryGetByIdAsync(Guid userId)
		{
			return await _databaseContext.Compares.Include(el => el.Products).ThenInclude(p => p.ImagesPath).FirstOrDefaultAsync(c => c.UserId == userId);
		}

		public async Task AddAsync(Guid userId, Guid productId)
		{
			var product = _databaseContext.Products.Include(p => p.ImagesPath).FirstOrDefault(el => el.Id == productId);
            var compare = await TryGetByIdAsync(userId);

			if (compare == null)
			{
				compare = new Compare() { UserId = userId, Products = new List<Product> { product } };
                await _databaseContext.Compares.AddAsync(compare);
            }
			else
				compare.Products.Add(product);

			await _databaseContext.SaveChangesAsync();
        }

		public async Task DeleteAsync(Guid userId, Guid productId)
		{
			var compare = await TryGetByIdAsync(userId);
			var compareItem = compare?.Products?.FirstOrDefault(p => p.Id == productId);

			if (compareItem != null)
				compare?.Products?.Remove(compareItem);
			await _databaseContext.SaveChangesAsync();
		}

		public async Task ClearAsync(Guid userId)
		{
			var compare = await TryGetByIdAsync(userId);
			compare?.Products?.Clear();
			await _databaseContext.SaveChangesAsync();
		}
    }
}
