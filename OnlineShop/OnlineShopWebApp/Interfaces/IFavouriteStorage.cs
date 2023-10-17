﻿using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
	public interface IFavouriteStorage
	{
		int Amount { get; }
		List<Product> GetAll();
		void Add(int productId);
		void Delete(int productId);
		void Clear();
	}
}
