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
        private readonly string filePath = "Storages/Orders.json";
        private List<Order> orders;

        public OrderStorageInJson()
        {
            orders = new List<Order>();
        }

        public void Add(OrderMiddle orderMiddle)
        {
            orders = GetAll();
            var order = new Order() { OrderMiddle = orderMiddle };
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

        public void Delete(Order order)
        {
            orders = GetAll();
            if (orders != null)
            {
                var orderForDelete = orders.FirstOrDefault(o => o.Id == order.Id);
                orders.Remove(orderForDelete);
                SaveAll(orders);
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

        public bool CheckBlankEmail(OrderMiddle orderMiddle)
        {
            return orders.Any(el => el.OrderMiddle.Cart.UserId == orderMiddle.Cart.UserId && String.IsNullOrEmpty(el.OrderMiddle.Email));
        }
    }
}
