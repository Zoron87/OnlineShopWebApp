using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICartStorage
    {
        Cart Get(Guid userGuid);
        void AddItem(Guid userId, int productId, int quantity = 1);
        void DeleteItem(Guid userId, int productId);
        Cart TryGetById(Guid userGuid);
        void Increase(Guid userId, int productId, int quantity = 1);
        void Reduce(Guid userId, int productId, int quantity = 1);
        void Clear(Guid userId);
    }
}
