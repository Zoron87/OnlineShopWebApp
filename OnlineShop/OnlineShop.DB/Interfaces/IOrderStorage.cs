using Microsoft.AspNetCore.Identity;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Interfaces
{
	public interface IOrderStorage
	{
        Task AddAsync(Order order);
        Task<List<Order>> GetAllAsync();
        Task<Order> TryGetByIdAsync(Guid orderId);
        Task UpdateStatusAsync(Guid orderId, OrderStatus orderStatus);
        Task DeleteAsync(Order order);
        Task<List<Order>> TryGetByUserIdAsync(Guid userId);
	}
}
