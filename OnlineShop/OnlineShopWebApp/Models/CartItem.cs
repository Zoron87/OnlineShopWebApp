namespace OnlineShopWebApp.Models
{
    public class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; set; }

        public CartItem(Product product, int quantity = 1)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
