using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IOrderStorage
    {
        void Add(OrderDetails orderDetails, Cart cart);
        void SaveAll(List<Order> orders);
        List<Order> GetAll();
    }
}
