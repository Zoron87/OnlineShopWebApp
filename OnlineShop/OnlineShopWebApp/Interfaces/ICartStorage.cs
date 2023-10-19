using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICartStorage
    {
        void AddItem(Guid userId, int productId, string operation, int quantity = 1);
        void DeleteItem(Guid userId, int productId);
        Cart TryGetById(Guid userGuid);
        void Clear(Guid userId);
    }
}
