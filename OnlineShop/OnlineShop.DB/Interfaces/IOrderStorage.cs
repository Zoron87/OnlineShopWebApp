using Microsoft.AspNetCore.Identity;
using OnlineShop.DB.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
	public interface IOrderStorage
	{
		void Add(Order order);
		List<Order> GetAll();
		Order TryGetById(Guid orderId);
		void UpdateStatus(Guid orderId, OrderStatus orderStatus);
		void Delete(Order order);
		void Mapping(Order order, OrderDetails orderDetails);
		List<Order> TryGetByUserId(string userId);
	}
}
