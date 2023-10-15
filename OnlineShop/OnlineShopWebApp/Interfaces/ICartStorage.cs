using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICartStorage
    {
        Cart Get(Guid userGuid);
        void AddItem(int productId, int quantity = 1);
        void DeleteItem(int productId);
        Cart TryGetById(Guid userGuid);
        void Increase(int productId, int quantity = 1);
        void Reduce(int productId, int quantity = 1);
        void Clear();
    }
}
