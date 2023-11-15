using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DB.Storages
{
    public class ProductDBStorage : IProductStorage
    {
        private readonly DatabaseContext databaseContext;

        public ProductDBStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }

        public void SaveChange()
        {
            databaseContext.SaveChanges();
        }

        public Product TryGetById(Guid id)
        {
            var product = databaseContext.Products.FirstOrDefault(product => product.Id == id);
            if (product == null) throw new Exception("Указанный продукт не обнаружен!");
            return product;
        }

        public void Delete(Guid id)
        {
            var product = TryGetById(id);
            if (product != null)
            {
                databaseContext.Products.Remove(product);
                databaseContext.SaveChanges();
            }
        }

        public void Add(Product product)
        {
            databaseContext.Add(product);
            databaseContext.SaveChanges();
        }

        public List<Product> GetProductsWithPagination(int page, int itemsOnPage)
        {
            if (page <= 0) throw new Exception("Номер страницы должен быть больше нуля!");
            if (CheckExistPage(page, itemsOnPage)) throw new Exception("Такой страницы не существует!");
            itemsOnPage = itemsOnPage < databaseContext.Products.Count() ? itemsOnPage : databaseContext.Products.Count();

            if (databaseContext.Products.Any())
                return GetOutputProducts(page, itemsOnPage);

            throw new Exception("Товаров для вывода не обнаружено!");
        }

        private bool CheckExistPage(int page, int itemsOnPage)
        {
            return page > 1 && databaseContext.Products.Count() - (page - 1) * itemsOnPage <= 0;
        }

        private List<Product> GetOutputProducts(int page, int itemsOnPage)
        {
            if (page > 1)
                return databaseContext.Products.Skip(page - 1 * itemsOnPage).Take(itemsOnPage).ToList();

            return databaseContext.Products.Take(itemsOnPage).ToList();
        }
    }
}