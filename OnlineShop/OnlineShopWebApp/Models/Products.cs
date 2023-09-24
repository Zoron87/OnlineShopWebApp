namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int counter = 1;
        public int Id { get; }
        private string Name { get; set; }
        private decimal Cost { get; set; }
        private string Description { get; set; }

        public Product(string name, decimal cost, string description)
        {
            Id = counter;
            Name = name;
            Cost = cost;
            Description = description;

            counter++;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}\n{Description}";
        }
    }
}
