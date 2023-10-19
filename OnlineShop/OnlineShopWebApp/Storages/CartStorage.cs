using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
	public class CartStorage : ICartStorage
	{
		private List<Cart> carts = new List<Cart>();
		private readonly IProductStorage productStorage;

		public CartStorage(IProductStorage productStorage)
		{
			this.productStorage = productStorage;
		}

		public void AddItem(Guid userId, int productId, string operation, int quantity = 1)
		{
			var product = productStorage.TryGetById(productId);

			Helpers<Product>.CheckNullItem(product);

			var cartPositon = new CartItem(product, quantity);
			var cart = TryGetById(userId);

			if (cart == null)
			{
				cart = new Cart(userId, new List<CartItem>() { cartPositon });
                carts.Add(cart);
            }
			else
			{
				var checkSameProduct = cart?.Items?.FirstOrDefault(cartItem => cartItem.Product.Id == product.Id);
				if (checkSameProduct != null)
				{
					switch (operation)
					{
						default:
						case "plus":
							checkSameProduct.Quantity += quantity;
							break;
						case "minus":
							if (checkSameProduct.Quantity - quantity <= 0)
								DeleteItem(userId, productId);
							else
								checkSameProduct.Quantity -= quantity;
							break;
					}
				}
				else
				{
					cart.Items.Add(cartPositon);
                   
                }
            }
		}

		public void DeleteItem(Guid userId, int productId)
		{
			var cart = TryGetById(userId);
			var cartItemForRemove = cart?.Items?.FirstOrDefault(cartItem => cartItem.Product.Id == productId);
            Helpers<CartItem>.CheckNullItem(cartItemForRemove);
			cart.Items.Remove(cartItemForRemove);
		}

		public Cart TryGetById(Guid userId)
		{
			return carts.FirstOrDefault(c => c.UserId == userId);
		}

		public void Clear(Guid userId)
		{
			var cart = TryGetById(userId);
			if (cart != null)
				carts.Remove(cart);
		}
	}
}
