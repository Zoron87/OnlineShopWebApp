using Microsoft.CodeAnalysis;
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
        private static string productsFilePath = "Storages/Products.json";
        private readonly List<Product> products;

        public ProductStorageInJson()
        {
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
                return DefaultProductStorage.GetAll();

            return JsonConvert.DeserializeObject<List<Product>>(allProducts);
        }

        public bool SaveAll(bool isAppend = false)
        {
            return FileProvider.SaveInfo(productsFilePath, JsonConvert.SerializeObject(products, Formatting.Indented));
        }

        public void SaveChange(int productId, Item item)
        {
            var product = TryGetById(productId);
            product.Name = item.Name;
            product.Description = item.Description;
            product.Cost = item.Cost;
        }

        public Product TryGetById(int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);
            product.CheckNullItem("Указанный товар не обнаружен");
            return product;
        }

        public void Delete(int id)
        {
            var product = TryGetById(id);
            if (product != null)
                products.Remove(product);
        }

        public void Add(Item item)
        {
            var product = new Product(item.Name, item.Cost, item.Description, item.ImagePath);
            products.Add(product);
        }

        public List<Product> GetProductsWithPagination(int page, int itemsOnPage)
        {
            if (page <= 0) throw new Exception("Номер страницы должен быть больше нуля!");

            if (CheckExistPage(page, itemsOnPage)) throw new Exception("Такой страницы не существует!");

            itemsOnPage = itemsOnPage < products.Count ? itemsOnPage : products.Count;

            var outputProducts = GetOutputProducts(page, itemsOnPage);

            if (products.Any())
                return GetOutputProducts(page, itemsOnPage);

            throw new Exception("Товаров для вывода не обнаружено!");
        }

        private bool CheckExistPage(int page, int itemsOnPage)
        {
            return page > 1 && (products.Count - (page - 1) * itemsOnPage <= 0);
        }

        private List<Product> GetOutputProducts(int page, int itemsOnPage)
        {
            var productsForView = products.Count - (page - 1) * itemsOnPage <= itemsOnPage ? products.Count - (page - 1) * itemsOnPage : itemsOnPage;
            return products.GetRange((page - 1) * itemsOnPage, productsForView);
        }
    }
}