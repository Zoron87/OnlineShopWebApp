using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICompareStorage
    {
        Compare Get(Guid userId);
        void Add(int productId);
        void Delete(int productId);
        void Clear(Guid userId);
    }
}
