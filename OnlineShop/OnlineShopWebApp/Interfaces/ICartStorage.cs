using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICartStorage
    {
        Cart Add(Guid userId, Product product);
        Cart Delete(Cart cart, int productId);
        Cart TryGetById(Guid userGuid);
    }
}
