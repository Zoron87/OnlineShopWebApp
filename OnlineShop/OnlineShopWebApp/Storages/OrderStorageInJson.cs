using Newtonsoft.Json;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
    public class OrderStorageInJson : IOrderStorage
    {
        private readonly string filePath = "Storages/Orders.txt";
        private List<Order> orders;

        public OrderStorageInJson()
        {
            orders = new List<Order>();
        }

        public void Add(OrderDetails orderDetails, Cart cart)
        {
            orders = GetAll();
            var order = new Order() { OrderDetails = orderDetails, Cart = cart };
            orders.Add(order);
            SaveAll(orders);
        }

        public Order Get(Guid orderId)
        {
            return GetAll().FirstOrDefault(order => order.Id == orderId);
        }

        public void SaveAll(List<Order> orders)
        {
            FileProvider.SaveInfo(filePath, JsonConvert.SerializeObject(orders, Formatting.Indented), false);
        }

        public void UpdateStatus(Guid orderId, OrderStatus orderStatus)
        {
            orders = GetAll();
            if (orders != null)
            {
                orders.FirstOrDefault(order => order.Id == orderId).OrderStatus = orderStatus;
                SaveAll(orders);
            }
        }

        public List<Order> GetAll()
        {
            var oldOrders = FileProvider.GetInfo(filePath);
            if (!String.IsNullOrEmpty(oldOrders))
                return JsonConvert.DeserializeObject<List<Order>>(oldOrders);

            return orders;
        }
    }
}
