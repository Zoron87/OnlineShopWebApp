using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
	public class CartStorage : ICartStorage
    {
        Cart cart;
		private List<Cart> carts = new List<Cart>();
        private readonly IProductStorage productStorage;

		public CartStorage(IProductStorage productStorage)
        {
			this.productStorage = productStorage;
		}

        public Cart Add(Guid userId, int productId)
        {
            cart = TryGetById(userId);

            var product = productStorage.TryGetById(productId);
             
            var cartPositon = new CartItem(product);

            if (cart == null)
            {
                cart = new Cart(userId, new List<CartItem>() { cartPositon });
            }
            else
            {
                var checkSameProduct = cart.Items.Any(ci => ci.Product.Id == product.Id);

                if (checkSameProduct)
                    cart.Items.FirstOrDefault(ci => ci.Product.Id == product.Id).Quantity++;
                else
                    cart.Items.Add(cartPositon);
            }

            carts.Add(cart);

            return cart;
        }

        public Cart Delete(Cart cart, int productId = 1)
        {
            var ItemForRemove = cart.Items.FirstOrDefault(ci => ci.Product.Id == productId);
            cart.Items.Remove(ItemForRemove);

            return cart;
        }

        public Cart TryGetById(Guid userId)
        {
            return carts.FirstOrDefault(c => c.UserId == userId);
        }
    }
}
