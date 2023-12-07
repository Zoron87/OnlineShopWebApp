﻿using Microsoft.AspNetCore.Identity;
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
        private readonly DatabaseContext _databaseContext;

        public OrderDBStorage(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public void Add(Order order)
        {
           _databaseContext.Orders.Add(order);
           _databaseContext.SaveChanges();
        }

        public Order TryGetById(Guid orderId)
        {
            return GetAll().FirstOrDefault(order => order.Id == orderId);
        }

		public List<Order> TryGetByUserId(Guid userId)
		{
			return GetAll().Where(order => order.UserId == userId).ToList();
		}

		public void UpdateStatus(Guid orderId, OrderStatus orderStatus)
        {
            var orders = GetAll();
            if (orders != null)
            {
                orders.FirstOrDefault(order => order.Id == orderId).OrderStatus = orderStatus;
                _databaseContext.SaveChanges();
            }
        }

        public List<Order> GetAll()
        {
            return _databaseContext.Orders.Include(el => el.OrderDetails).ThenInclude(el => el.Items).ThenInclude(el => el.Product).ThenInclude(el => el.ImagesPath).ToList();
        }

        public void Delete(Order order)
        {
            var orders = GetAll();
            if (orders != null)
            {
                var orderForDelete = orders.FirstOrDefault(o => o.Id == order.Id);
                orders.Remove(orderForDelete);
                _databaseContext.SaveChanges();
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
