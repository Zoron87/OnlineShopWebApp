﻿using Newtonsoft.Json;
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
        private static readonly List<Product> products = InitProducts();
        public List<Product> GetAll()
        {
            return products;
        }
        private static List<Product> InitProducts()
        {
            var allProducts = FileProvider.GetInfo(productsFilePath);

            if (String.IsNullOrEmpty(allProducts))
                return new ProductStorageInit().GetAll();

            return JsonConvert.DeserializeObject<List<Product>>(allProducts);
        }

        public bool SaveAll(bool isAppend = false)
        {
            if (FileProvider.SaveInfo(productsFilePath, JsonConvert.SerializeObject(products, Formatting.Indented)))
                return true;

            return false;
        }

        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public List<Product> GetProductsWithPagination(int page, int itemsonpage)
        {
            if (page <= 0) throw new Exception("Номер страницы должен быть больше нуля!");
            if (itemsonpage <= 0) throw new Exception("Количество товаров на странице должно быть больше нуля!");


            if ((page - 1) * itemsonpage >= products.Count - 1)
                throw new Exception("Такой страницы не существует!");

            itemsonpage = (itemsonpage < products.Count - 1) ? itemsonpage : products.Count - 1;

            var outputProducts = products.GetRange((page - 1) * itemsonpage, itemsonpage);

            if (products.Any())
                return outputProducts;

            throw new Exception("Товаров для вывода не обнаружено!");
        }
    }
}