using OnlineShop.DB.Models;
using System;

namespace OnlineShop.DB.Interfaces
{
    public interface ICartStorage
    {
        void AddItem(Guid userId, Guid productId, int quantity = 1);
        void Reduce(Guid userId, Guid productId);
        void DeleteItem(Guid userId, Guid productId);
        Cart TryGetById(Guid userGuid);
        void Clear(Guid userId);
    }
}
