using OnlineShop.DB.Models;
using System;

namespace OnlineShop.DB.Interfaces
{
    public interface ICompareStorage
    {
        Compare TryGetById(Guid userId);
        void Add(Guid userId, Guid productId);
        void Delete(Guid userId, Guid productId);
        void Clear(Guid userId);
    }
}
