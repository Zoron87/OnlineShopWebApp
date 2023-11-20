using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;
using OnlineShopWebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DB.Storages
{
    public class OrderDBStorage : IOrderStorage
    {
        private readonly DatabaseContext databaseContext;

        public OrderDBStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Order order)
        {
           databaseContext.Orders.Add(order);
           databaseContext.SaveChanges();
        }

        public Order TryGetById(Guid orderId)
        {
            return GetAll().FirstOrDefault(order => order.Id == orderId);
        }

        public void UpdateStatus(Guid orderId, OrderStatus orderStatus)
        {
            var orders = GetAll();
            if (orders != null)
            {
                orders.FirstOrDefault(order => order.Id == orderId).OrderStatus = orderStatus;
                databaseContext.SaveChanges();
            }
        }

        public List<Order> GetAll()
        {
            return databaseContext.Orders.Include(el => el.OrderDetails).ThenInclude(el => el.Items).ThenInclude(el => el.Product).ToList();
        }

        public void Delete(Order order)
        {
            var orders = GetAll();
            if (orders != null)
            {
                var orderForDelete = orders.FirstOrDefault(o => o.Id == order.Id);
                orders.Remove(orderForDelete);
                databaseContext.SaveChanges();
            }
        }

        public void Mapping(Order order, OrderDetails orderDetails)
        {
            order.OrderDetails.Name = orderDetails.Name;
            order.OrderDetails.Email = orderDetails.Email;
            order.OrderDetails.Address = orderDetails.Address;
            order.OrderDetails.Comment = orderDetails.Comment;
            order.OrderDetails.Delivery = orderDetails.Delivery;
            order.OrderDetails.DeliveryDate = orderDetails.DeliveryDate;
            order.OrderDetails.Pay = orderDetails.Pay;
            order.OrderDetails.Phone = orderDetails.Phone;
        }
    }
}
