using Microsoft.EntityFrameworkCore;
using OnlineShop.DB;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Storages
{
    public class FavouriteStorage : IFavouriteStorage
	{
        private readonly DatabaseContext _databaseContext;

        public FavouriteStorage(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public async Task<Favourite> TryGetByIdAsync(Guid userId)
		{
			return await _databaseContext.Favourites.Include(el => el.Products).ThenInclude(p => p.ImagesPath).FirstOrDefaultAsync(f => f.UserId == userId);
		}

		public async Task AddAsync(Guid userId, Guid productId)
		{
			var product = await _databaseContext.Products.Include(p => p.ImagesPath).FirstOrDefaultAsync(el => el.Id == productId);

			if (product == null) throw new Exception("Указанный товар не обнаружен!");

			var favourite = await TryGetByIdAsync(userId);
			if (favourite == null)
			{
				favourite = new Favourite() { UserId = userId, Products = new List<Product> { product } };
                await _databaseContext.Favourites.AddAsync(favourite);
            }
			else
				favourite.Products.Add(product);
            
            await _databaseContext.SaveChangesAsync();
        }

		public async Task ClearAsync(Guid userId)
		{
            var favourite = await TryGetByIdAsync(userId);
			_databaseContext.Favourites.Remove(favourite);
			await _databaseContext.SaveChangesAsync() ;
		}

		public async Task DeleteAsync(Guid userId, Guid productId)
		{
            var favourite = await TryGetByIdAsync(userId);
			var favouriteItem = await _databaseContext?.Products?.Include(p => p.ImagesPath).FirstOrDefaultAsync(p => p.Id == productId);

			if (favouriteItem != null)
				favourite?.Products?.Remove(favouriteItem);
			await _databaseContext.SaveChangesAsync() ;
		}
	}
}
