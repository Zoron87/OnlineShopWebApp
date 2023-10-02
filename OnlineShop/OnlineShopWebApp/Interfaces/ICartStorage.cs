using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICartStorage
    {
        Cart Add(Guid userGuid, List<CartItem> cartItem);
        List<Cart> GetAll();
        Cart TryGetById(Guid userGuid);
    }
}
