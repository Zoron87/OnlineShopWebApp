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

		public void AddItem(Guid userId, int productId, int quantity = 1)
		{
			var product = productStorage.TryGetById(productId);

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
                    checkSameProduct.Quantity += quantity;
				else
					cart.Items.Add(cartPositon);
            }
		}

		public void Reduce(Guid userId, int productId)
		{
			var cart = TryGetById(userId);
			var checkSameProduct = cart?.Items?.FirstOrDefault(cartItem => cartItem.Product.Id == productId);
			if (checkSameProduct != null)
			{
                if (checkSameProduct.Quantity <= 1)
                    DeleteItem(userId, productId);
                else
                    checkSameProduct.Quantity--;
            }
		}

		public void DeleteItem(Guid userId, int productId)
		{
			var cart = TryGetById(userId);
			var cartItemForRemove = cart?.Items?.FirstOrDefault(cartItem => cartItem.Product.Id == productId);
            Helpers<CartItem>.CheckNullItem(cartItemForRemove, "Указанная позиция не обнаружена!");
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
