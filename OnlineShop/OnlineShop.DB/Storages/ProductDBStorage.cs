using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DB.Storages
{
    public class ProductDBStorage : IProductStorage
    {
        private readonly DatabaseContext _databaseContext;

        public ProductDBStorage(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public List<Product> GetAll()
        {
            return _databaseContext.Products.ToList();
        }

        public void SaveChange()
        {
            _databaseContext.SaveChanges();
        }

        public Product TryGetById(Guid id)
        {
            var product = _databaseContext.Products.FirstOrDefault(product => product.Id == id);
            if (product == null) throw new Exception("Указанный продукт не обнаружен!");
            return product;
        }

        public void Delete(Guid id)
        {
            var product = TryGetById(id);
            if (product != null)
            {
                _databaseContext.Products.Remove(product);
                _databaseContext.SaveChanges();
            }
        }

        public void Add(Product product)
        {
            _databaseContext.Add(product);
            _databaseContext.SaveChanges();
        }

        public List<Product> GetProductsWithPagination(int page, int itemsOnPage)
        {
            if (page <= 0) throw new Exception("Номер страницы должен быть больше нуля!");
            if (CheckExistPage(page, itemsOnPage)) throw new Exception("Такой страницы не существует!");
            itemsOnPage = itemsOnPage < _databaseContext.Products.Count() ? itemsOnPage : _databaseContext.Products.Count();

            if (_databaseContext.Products.Any())
                return GetOutputProducts(page, itemsOnPage);

            throw new Exception("Товаров для вывода не обнаружено!");
        }

        private bool CheckExistPage(int page, int itemsOnPage)
        {
            return page > 1 && _databaseContext.Products.Count() - (page - 1) * itemsOnPage <= 0;
        }

        private List<Product> GetOutputProducts(int page, int itemsOnPage)
        {
            if (page > 1)
                return _databaseContext.Products.Skip(page - 1 * itemsOnPage).Take(itemsOnPage).ToList();

            return _databaseContext.Products.Take(itemsOnPage).ToList();
        }
    }
}