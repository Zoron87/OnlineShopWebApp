using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
    public class CartStorage
    {
        private static List<Cart> carts = new List<Cart>();

        public Cart Add(Guid userId, Product product)
        {
            var cart = TryGetById(userId);

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

        public List<Cart> GetAll()
        {
            return carts;
        }

        public Cart TryGetById(Guid userId)
        {
            return carts.FirstOrDefault(c => c.UserId == userId);
        }
    }
}
