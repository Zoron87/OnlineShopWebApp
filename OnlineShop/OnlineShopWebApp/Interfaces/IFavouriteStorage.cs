using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface IFavouriteStorage
    {
        Favourite Get(Guid userId);
        void Add(int productId);
        void Delete(int productId);
        void Clear(Guid userId);
    }
}
