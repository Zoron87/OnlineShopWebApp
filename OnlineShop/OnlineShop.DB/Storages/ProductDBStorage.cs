using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Interfaces;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.DB.Storages
{
    public class ProductDBStorage : IProductStorage
    {
        private readonly DatabaseContext _databaseContext;

        public ProductDBStorage(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _databaseContext.Products.Include(p => p.ImagesPath).ToListAsync();
        }

        public async Task SaveChangeAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Product> TryGetByIdAsync(Guid id)
        {
            var product = await _databaseContext.Products.Include(p => p.ImagesPath).FirstOrDefaultAsync(product => product.Id == id);
            if (product == null) throw new Exception("Указанный продукт не обнаружен!");
            return product;
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await TryGetByIdAsync(id);
            if (product != null)
            {
                _databaseContext.Products.Remove(product);
                await _databaseContext.SaveChangesAsync();
            }
        }

        public async Task AddAsync(Product product)
        {
            await _databaseContext.AddAsync(product);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductsWithPaginationAsync(int page, int itemsOnPage)
        {
            if (page <= 0) throw new Exception("Номер страницы должен быть больше нуля!");
            if (await CheckExistPageAsync(page, itemsOnPage)) throw new Exception("Такой страницы не существует!");
            itemsOnPage = itemsOnPage < _databaseContext.Products.Count() ? itemsOnPage : _databaseContext.Products.Count();

            if (_databaseContext.Products.Any())
                return await GetOutputProductsAsync(page, itemsOnPage);

            throw new Exception("Товаров для вывода не обнаружено!");
        }

        private async Task<bool> CheckExistPageAsync(int page, int itemsOnPage)
        {
            return page > 1 && await _databaseContext.Products.CountAsync() - (page - 1) * itemsOnPage <= 0;
        }

        private async Task<List<Product>> GetOutputProductsAsync(int page, int itemsOnPage)
        {
            if (page > 1)
                return await _databaseContext.Products.Include(el => el.ImagesPath).Skip((page - 1) * itemsOnPage).Take(itemsOnPage).ToListAsync();

            return _databaseContext.Products.Include(el => el.ImagesPath).Take(itemsOnPage).ToList();
        }
    }
}