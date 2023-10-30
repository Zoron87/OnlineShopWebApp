using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IOrderStorage
	{
		void Add(OrderDetails orderDetails, Cart cart);
		void SaveAll(List<Order> orders);
		List<Order> GetAll();
		Order Get(Guid orderId);
		void UpdateStatus(Guid orderId, OrderStatus orderStatus);
    }
}
