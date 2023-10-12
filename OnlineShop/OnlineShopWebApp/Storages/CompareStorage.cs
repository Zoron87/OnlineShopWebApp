using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Storages
{
    public class CompareStorage : ICompareStorage
    {
        private readonly IProductStorage productStorage;
        private List<Product> compareProducts = new List<Product>();

        public CompareStorage(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        public List<Product> GetAll()
        {
            return compareProducts;
        }

        public List<Product> Add(int productId)
        {
            var product = productStorage.TryGetById(productId);

            if (product == null)
                throw new System.Exception("Указанный товар не найден");

            compareProducts.Add(product);
            return compareProducts;
        }

        public List<Product> Delete(int productId)
        {
            var product = productStorage.TryGetById(productId);

            if (product == null)
                throw new System.Exception("Указанный товар не найден");

            compareProducts.Remove(product);
            return compareProducts;
        }

        public List<Product> Clear()
        {
            compareProducts.Clear();
            return compareProducts;
        }
    }
}
