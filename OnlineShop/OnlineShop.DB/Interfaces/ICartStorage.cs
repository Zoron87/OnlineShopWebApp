using OnlineShop.DB.Models;
using System;

namespace OnlineShop.DB.Interfaces
{
    public interface ICartStorage
    {
        void AddItem(string userId, Guid productId, int quantity = 1);
        void Reduce(string userId, Guid productId);
        void DeleteItem(string userId, Guid productId);
        Cart TryGetById(string userGuid);
        void Clear(string userId);
    }
}
