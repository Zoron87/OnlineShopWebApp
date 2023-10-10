using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
    public class CartStorage : ICartStorage
    {
        private Cart cart;
        private List<Cart> carts = new List<Cart>();
        private readonly IProductStorage productStorage;

        public CartStorage(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
            cart = TryGetById(ShopUser.Id);
        }

        public Cart AddItem(int productId, int quantity = 1)
        {
            var product = productStorage.TryGetById(productId);

            var cartPositon = new CartItem(product, quantity);

            if (cart == null)
            {
                cart = new Cart(ShopUser.Id, new List<CartItem>() { cartPositon });
            }
            else
            {
                var checkSameProduct = cart.Items.Any(ci => ci.Product.Id == product.Id);

                if (checkSameProduct)
                    cart.Items.FirstOrDefault(ci => ci.Product.Id == product.Id).Quantity += quantity;
                else
                    cart.Items.Add(cartPositon);
            }

            carts.Add(cart);

            return cart;
        }

        public Cart DeleteItem(int productId)
        {
            var ItemForRemove = cart.Items.FirstOrDefault(ci => ci.Product.Id == productId);
            cart.Items.Remove(ItemForRemove);

            return cart;
        }

        public Cart Increase(int productId, int quantity = 1)
        {
            var product = cart.Items.FirstOrDefault(pId => pId.Product.Id == productId);

            if (product != null)
                product.Quantity += quantity;

            return cart;
        }

        public Cart Reduce(int productId, int quantity = 1)
        {
            var product = cart.Items.FirstOrDefault(pId => pId.Product.Id == productId);

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
