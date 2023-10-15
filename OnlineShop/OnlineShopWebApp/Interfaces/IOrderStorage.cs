using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IOrderStorage
    {
        void Add(Order order);
        void SaveAll(List<Order> orders);
        List<Order> GetAll();
    }
}
