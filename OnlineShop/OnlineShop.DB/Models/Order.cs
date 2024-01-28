using System;

namespace OnlineShop.DB.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedTime { get; set; }

        public Order()
        {
            CreatedTime = DateTime.Now;
            OrderStatus = OrderStatus.Created;
        }
    }
}
