namespace OnlineShopWebApp.Models
{
	public class Order
	{
		public OrderDetails OrderDetails;
		public Cart Cart;

		public Order(OrderDetails orderDetails, Cart cart)
		{
			OrderDetails = orderDetails;
			Cart = cart;
		}
	}
}
