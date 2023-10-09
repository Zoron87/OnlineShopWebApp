using Newtonsoft.Json;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
	public class ProductStorageInJson : IProductStorage
    {
        private static string productsFilePath = "Storages/Products.txt";
        private readonly List<Product> products;
		private readonly ProductStorageInit productStorageInit;

		public ProductStorageInJson(ProductStorageInit productStorageInit)
        {
			this.productStorageInit = productStorageInit;
            products = InitProducts();
		}

        public List<Product> GetAll()
        {
            return products;
        }
        private List<Product> InitProducts()
        {
            var allProducts = FileProvider.GetInfo(productsFilePath);

			if (String.IsNullOrEmpty(allProducts))
			    return productStorageInit.GetAll();

			return JsonConvert.DeserializeObject<List<Product>>(allProducts);
        }

        public bool SaveAll(bool isAppend = false)
        {
            return FileProvider.SaveInfo(productsFilePath, JsonConvert.SerializeObject(products, Formatting.Indented));
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public List<Product> GetProductsWithPagination(int page, int itemsonpage)
        {
            if (page <= 0) throw new Exception("Номер страницы должен быть больше нуля!");

            if (CheckExistPage(page, itemsonpage)) throw new Exception("Такой страницы не существует!");

            itemsonpage = itemsonpage < products.Count ? itemsonpage : products.Count;

            var outputProducts = GetOutputProducts(page, itemsonpage);

            if (products.Any()) 
                return GetOutputProducts(page, itemsonpage);
            
            throw new Exception("Товаров для вывода не обнаружено!");
        }

        private bool CheckExistPage(int page, int itemsonpage)
        {
            return page > 1 && (products.Count - (page - 1) * itemsonpage <= 0);
        }

        private List<Product> GetOutputProducts(int page, int itemsonpage)
        {
            return products.GetRange((page - 1) * itemsonpage, page > 1 ? products.Count - (page - 1) * itemsonpage : itemsonpage);
        }
    }
}