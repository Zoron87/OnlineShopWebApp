using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Storages
{
    public class FavouriteStorage : IFavouriteStorage
    {
        private readonly IProductStorage productStorage;
        private List<Product> favouriteProducts = new List<Product>();

        public FavouriteStorage(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }
        public List<Product> Add(int productId)
        {
            var product = productStorage.TryGetById(productId);

            if (product != null)
                favouriteProducts.Add(product);
            return favouriteProducts;
        }

        public List<Product> Clear()
        {
            favouriteProducts.Clear();
            return favouriteProducts;
        }

        public List<Product> Delete(int productId)
        {
            var product = productStorage.TryGetById(productId);

            if (product != null)
                favouriteProducts.Remove(product);
            return favouriteProducts;
        }

        public List<Product> GetAll()
        {
            return favouriteProducts;
        }
    }
}
