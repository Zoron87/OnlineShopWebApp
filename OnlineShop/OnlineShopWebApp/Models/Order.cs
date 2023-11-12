using System;

namespace OnlineShopWebApp.Models
{
    public class Order
	{
		public Guid Id { get; set; }
		public OrderMiddle OrderMiddle { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public DateTime CreatedTime { get; set; } 

        public Order()
        {
            Id = Guid.NewGuid();
			OrderStatus = OrderStatus.Created;
			CreatedTime = DateTime.Now;
        }
    }
}
