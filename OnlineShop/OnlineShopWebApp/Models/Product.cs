namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int counter = 1;
        public int Id { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public string Description { get; }
        public string Image { get; }

        public Product(string name, decimal cost, string description, string image)
        {
            Id = counter;
            Name = name;
            Cost = cost;
            Description = description;
            Image = image;

            counter++;
        }
    }
}
