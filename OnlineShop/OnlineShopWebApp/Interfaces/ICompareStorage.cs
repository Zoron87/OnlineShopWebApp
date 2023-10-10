using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICompareStorage
    {
        List<Product> Add(int productId);
        List<Product> DeleteItem(int productId);
        List<Product> Clear();
    }
}
