using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICartStorage
    {
        Cart AddItem(int productId);
        Cart DeleteItem(int productId);
        Cart TryGetById(Guid userGuid);
        Cart IncreaseProductCount(int productId, int quantity = 1);
        Cart ReduceProductCount(int productId, int quantity = 1);

	}
}
