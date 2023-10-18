using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface IFavouriteStorage
    {
        Favourite Get(Guid userId);
        void Add(Guid userId, int productId);
        void Delete(Guid userId, int productId);
        void Clear(Guid userId);
    }
}
