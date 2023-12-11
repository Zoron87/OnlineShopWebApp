using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.DB.Storages
{
    public class CartDBStorage : ICartStorage
    {
        private readonly DatabaseContext _databaseContext;

        public CartDBStorage(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddItemAsync(Guid userId, Guid productId, int quantity = 1)
        {
            var product = await _databaseContext.Products.Include(el => el.ImagesPath).FirstOrDefaultAsync(p => p.Id == productId);

            var cartPositon = new CartItem()
            {
                Product = product,
                Quantity = quantity
            };

            var cart = await TryGetByIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart()
                {
                    UserId = userId,
                    Items = new List<CartItem>() { cartPositon }
                };
                await _databaseContext.Carts.AddAsync(cart);
                await _databaseContext.SaveChangesAsync();
            }
            else
            {
                var checkSameProduct = cart?.Items?.FirstOrDefault(el => el.Product.Id == productId);
                if (checkSameProduct != null)
                    checkSameProduct.Quantity += quantity;
                else
                    cart.Items.Add(cartPositon);

                await _databaseContext.SaveChangesAsync();
            }
        }

        public async Task ReduceAsync(Guid userId, Guid productId)
        {
            var cart = await TryGetByIdAsync(userId);
            var checkSameProduct = cart?.Items?.FirstOrDefault(el => el.Product.Id == productId);
            if (checkSameProduct != null)
            {
                if (checkSameProduct.Quantity <= 1)
                    DeleteItemAsync(userId, productId);
                else
                    checkSameProduct.Quantity--;

                await _databaseContext.SaveChangesAsync();
            }
        }

        public async Task DeleteItemAsync(Guid userId, Guid productId)
        {
            var cart = await TryGetByIdAsync(userId);
            if (cart != null)
            {
                var cartItemForRemove = cart.Items.FirstOrDefault(el => el.Product.Id == productId);
                if (cartItemForRemove != null)
                    _databaseContext.Carts.FirstOrDefault(el => el == cart).Items.Remove(cartItemForRemove);
            }
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Cart> TryGetByIdAsync(Guid userId)
        {
            return await _databaseContext.Carts.Include(el => el.Items).ThenInclude(el => el.Product).ThenInclude(el => el.ImagesPath).FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task ClearAsync(Guid userId)
        {
            var cart = await TryGetByIdAsync(userId);
            if (cart != null)
            {
                _databaseContext.Carts.Remove(cart);
                await _databaseContext.SaveChangesAsync();
            }
        }
    }
}
