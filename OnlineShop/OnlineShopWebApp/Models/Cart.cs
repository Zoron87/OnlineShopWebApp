using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
	public class Cart
	{
		public int Id { get; }
		public Guid UserId { get; }
		public List<CartItem> Items { get; set; }

		public Cart(Guid userId, List<CartItem> items)
		{
			UserId = userId;
			Items = items;
		}

		public decimal Cost()
		{
			return Items.Sum(s => s.Product.Cost * s.Quantity);
		}
	}
}
