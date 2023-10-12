using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICartStorage
    {
        Cart Get(Guid userGuid);
        Cart AddItem(int productId, int quantity = 1);
        Cart DeleteItem(int productId);
        Cart TryGetById(Guid userGuid);
        Cart Increase(int productId, int quantity = 1);
        Cart Reduce(int productId, int quantity = 1);
    }
}
