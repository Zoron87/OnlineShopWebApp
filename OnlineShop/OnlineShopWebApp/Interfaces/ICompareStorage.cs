using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICompareStorage
    {
        List<Product> Add(Product productId);
        bool Clear();
    }
}
