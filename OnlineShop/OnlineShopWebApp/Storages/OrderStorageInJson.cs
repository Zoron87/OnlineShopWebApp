using Newtonsoft.Json;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;

namespace OnlineShopWebApp.Storages
{
    public class OrderStorageInJson : IOrderStorage
    {
        private readonly string filePath = "Storages/Orders.txt";

        public OrderDetails OrderDetails;
        public Cart Cart;

        public bool Save(OrderDetails orderDetails, Cart cart, bool isAppend = true)
        {
            var orderStorage = new OrderStorageInJson()
            {
                OrderDetails = orderDetails,
                Cart = cart
            };
            return FileProvider.SaveInfo(filePath, JsonConvert.SerializeObject(orderStorage, Formatting.Indented), isAppend);
        }
    }
}
