using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
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

        public Cart Get(Guid userGuid)
        {
            return TryGetById(userGuid);
        }

        public Cart GetCart(Guid userId)
        {
            return TryGetById(userId);
        }

        public Cart AddItem(int productId, int quantity = 1)
        {
            var product = productStorage.TryGetById(productId);

            if (product == null)
                throw new Exception("Указанный товар не обнаружен");

            var cartPositon = new CartItem(product, quantity);

            var cart = Get(ShopUser.Id);

            if (cart == null)
            {
                cart = new Cart(ShopUser.Id, new List<CartItem>() { cartPositon });
            }
            else
            {
                var checkSameProduct = cart.Items.Any(cartItem => cartItem.Product.Id == product.Id);

                if (checkSameProduct)
                    cart.Items.FirstOrDefault(cartItem => cartItem.Product.Id == product.Id).Quantity += quantity;
                else
                    cart.Items.Add(cartPositon);
            }

            carts.Add(cart);

            return cart;
        }

        public Cart DeleteItem(int productId)
        {
            var cart = Get(ShopUser.Id);

            var itemForRemove = cart.Items.FirstOrDefault(cartItem => cartItem.Product.Id == productId);
            cart.Items.Remove(itemForRemove);

            return cart;
        }

        public Cart Increase(int productId, int quantity = 1)
        {
            var cart = Get(ShopUser.Id);

            var product = cart.Items.FirstOrDefault(p => p.Product.Id == productId);

            if (product != null)
                product.Quantity += quantity;
            else
                throw new Exception("Указанный товар не обнаружен");

            return cart;
        }

        public Cart Reduce(int productId, int quantity = 1)
        {
            var cart = Get(ShopUser.Id);

            var product = cart.Items.FirstOrDefault(p => p.Product.Id == productId);

            if (product == null) return cart;

            if (product.Quantity - quantity <= 0)
                DeleteItem(productId);
            else
                product.Quantity -= quantity;

            return cart;
        }

        public Cart TryGetById(Guid userId)
        {
            return carts.FirstOrDefault(c => c.UserId == userId);
        }
    }
}
