using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface ICompareStorage
    {
        List<Product> GetAll();
        List<Product> Add(int productId);
        List<Product> Delete(int productId);
        List<Product> Clear();
    }
}
