using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICartStorage
    {
        Cart Add(Guid userId, int productId);
        Cart Delete(Cart cart, int productId);
        Cart TryGetById(Guid userGuid);
    }
}
