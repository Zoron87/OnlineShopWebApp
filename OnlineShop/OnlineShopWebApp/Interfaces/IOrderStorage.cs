using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IOrderStorage
	{
		void Add(OrderMiddle orderMiddle);
		void SaveAll(List<Order> orders);
		List<Order> GetAll();
		Order Get(Guid orderId);
		void UpdateStatus(Guid orderId, OrderStatus orderStatus);
		void Delete(Order order);
        void Mapping(Order order, OrderDetails orderDetails);
		bool CheckBlankEmail(OrderMiddle orderMiddle);
    }
}
