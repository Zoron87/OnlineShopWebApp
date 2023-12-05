using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DB.Storages
{
    public class CartDBStorage : ICartStorage
    {
        private readonly DatabaseContext _databaseContext;

        public CartDBStorage(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public void AddItem(Guid userId, Guid productId, int quantity = 1)
        {
            var product = _databaseContext.Products.Include(el => el.ImagesPath).FirstOrDefault(p => p.Id == productId);

            var cartPositon = new CartItem()
            {
                Product = product,
                Quantity = quantity
            };

            var cart = TryGetById(userId);
            if (cart == null)
            {
                cart = new Cart()
                {
                    UserId = userId,
                    Items = new List<CartItem>() { cartPositon }
                };
                _databaseContext.Carts.Add(cart);
                _databaseContext.SaveChanges();
            }
            else
            {
                var checkSameProduct = cart?.Items?.FirstOrDefault(el => el.Product.Id == productId);
                if (checkSameProduct != null)
                    checkSameProduct.Quantity += quantity;
                else
                    cart.Items.Add(cartPositon);

                _databaseContext.SaveChanges();
            }
        }

        public void Reduce(Guid userId, Guid productId)
        {
            var cart = TryGetById(userId);
            var checkSameProduct = cart?.Items?.FirstOrDefault(el => el.Product.Id == productId);
            if (checkSameProduct != null)
            {
                if (checkSameProduct.Quantity <= 1)
                    DeleteItem(userId, productId);
                else
                    checkSameProduct.Quantity--;

                _databaseContext.SaveChanges();
            }
        }

        public void DeleteItem(Guid userId, Guid productId)
        {
            var cart = TryGetById(userId);
            if (cart != null)
            {
                var cartItemForRemove = cart.Items.FirstOrDefault(el => el.Product.Id == productId);
                if (cartItemForRemove != null)
                    _databaseContext.Carts.FirstOrDefault(el => el == cart).Items.Remove(cartItemForRemove);
            }
            _databaseContext.SaveChanges();
        }

        public Cart TryGetById(Guid userId)
        {
            return _databaseContext.Carts.Include(el => el.Items).ThenInclude(el => el.Product).ThenInclude(el => el.ImagesPath).FirstOrDefault(c => c.UserId == userId);
        }

        public void Clear(Guid userId)
        {
            var cart = TryGetById(userId);
            if (cart != null)
            {
                _databaseContext.Carts.Remove(cart);
                _databaseContext.SaveChanges();
            }
        }
    }
}
