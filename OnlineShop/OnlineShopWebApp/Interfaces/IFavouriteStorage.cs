using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface IFavouriteStorage
    {
        Favourite TryGetById(Guid userId);
        void Add(Guid userId, Guid productId);
        void Delete(Guid userId, Guid productId);
        void Clear(Guid userId);
    }
}
