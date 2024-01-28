using System;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
	{
		public Guid Id { get; set; }
        public Guid UserId { get; }
        public OrderDetailsViewModel OrderDetails { get; set; }
		public OrderStatusViewModel OrderStatus { get; set; }
		public DateTime CreatedTime { get; set; } 
    }
}
