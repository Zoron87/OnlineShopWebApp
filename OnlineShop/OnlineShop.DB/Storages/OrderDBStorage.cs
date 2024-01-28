using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.DB.Storages
{
    public class OrderDBStorage : IOrderStorage
    {
        private readonly DatabaseContext _databaseContext;

        public OrderDBStorage(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddAsync(Order order)
        {
            await _databaseContext.Orders.AddAsync(order);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Order> TryGetByIdAsync(Guid orderId)
        {
            return (await GetAllAsync()).FirstOrDefault(order => order.Id == orderId);
        }

        public async Task<List<Order>> TryGetByUserIdAsync(Guid userId)
        {
            return (await GetAllAsync()).Where(order => order.UserId == userId).ToList();
        }

        public async Task UpdateStatusAsync(Guid orderId, OrderStatus orderStatus)
        {
            var orders = await GetAllAsync();
            if (orders != null)
            {
                orders.FirstOrDefault(order => order.Id == orderId).OrderStatus = orderStatus;
                await _databaseContext.SaveChangesAsync();
            }
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _databaseContext.Orders.Include(el => el.OrderDetails).ThenInclude(el => el.Items).ThenInclude(el => el.Product).ThenInclude(el => el.ImagesPath).ToListAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            var orders = await GetAllAsync();
            if (orders != null)
            {
                var orderForDelete = orders.FirstOrDefault(o => o.Id == order.Id);
                orders.Remove(orderForDelete);
                await _databaseContext.SaveChangesAsync();
            }
        }
    }
}
