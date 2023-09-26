using Newtonsoft.Json;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Repositories
{
    public class ProductStorageInJson : IProductStorage
    {
        private static string productsFilePath = "Storages/Products.txt";

        public List<Product> GetAll()
        {
            var allProducts = FileProvider.GetInfo(productsFilePath);

            if (String.IsNullOrEmpty(allProducts))
               return new ProductStorageInit().GetAll();

            return JsonConvert.DeserializeObject<List<Product>>(allProducts);
        }

        public bool SaveAll(bool isAppend = false)
        {
            var allProducts = GetAll();

            if (FileProvider.SaveInfo(productsFilePath, JsonConvert.SerializeObject(allProducts, Formatting.Indented)))
                return true;
           
            return false; 
        }

        public Product TryGetById(int id)
        {
            var allProducts = GetAll();

            return allProducts.FirstOrDefault(product => product.Id == id);
        }
    }
}
