using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface IOrderStorage
    {
        bool Save(OrderDetails orderDetails, Cart cart, bool isAppend = true);
    }
}
