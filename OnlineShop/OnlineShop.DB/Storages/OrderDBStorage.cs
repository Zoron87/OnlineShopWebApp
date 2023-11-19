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
            return databaseContext.Orders.Include(el => el.OrderMiddle).ThenInclude(el => el.Items).ThenInclude(el => el.Product).ToList();
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
            order.OrderMiddle.Name = orderDetails.Name;
            order.OrderMiddle.Email = orderDetails.Email;
            order.OrderMiddle.Address = orderDetails.Address;
            order.OrderMiddle.Comment = orderDetails.Comment;
            order.OrderMiddle.Delivery = orderDetails.Delivery;
            order.OrderMiddle.DeliveryDate = orderDetails.DeliveryDate;
            order.OrderMiddle.Pay = orderDetails.Pay;
            order.OrderMiddle.Phone = orderDetails.Phone;
        }
    }
}
