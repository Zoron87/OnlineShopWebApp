using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using Newtonsoft.Json;

namespace OnlineShopWebApp.Storages
{
    public class OrderStorage : IOrderStorage
    {
        private readonly string filePath = "Storages/Orders.txt";
        private readonly OrderItem orderItem;
        private readonly Cart cart;

        public OrderStorage(OrderItem orderItem, Cart cart)
        {
            this.orderItem = orderItem;
            this.cart = cart;
        }

        public bool Save(bool isAppend = false)
        {
            return FileProvider.SaveInfo(filePath, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
