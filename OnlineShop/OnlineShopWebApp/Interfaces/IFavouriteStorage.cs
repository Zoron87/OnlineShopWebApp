using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
	public interface IFavouriteStorage
	{
		List<Product> GetAll();
		void Add(int productId);
		void Delete(int productId);
		void Clear();
	}
}
