namespace OnlineShopWebApp.Models
{
    public class Item
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string ImagePath { get; set; }
    }
}