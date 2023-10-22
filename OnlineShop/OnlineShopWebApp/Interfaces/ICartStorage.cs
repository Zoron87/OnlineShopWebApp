using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICartStorage
    {
        void AddItem(Guid userId, int productId, int quantity = 1);
        void Reduce(Guid userId, int productId);
        void DeleteItem(Guid userId, int productId);
        Cart TryGetById(Guid userGuid);
        void Clear(Guid userId);
    }
}
