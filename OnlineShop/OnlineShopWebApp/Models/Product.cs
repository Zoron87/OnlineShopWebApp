using System;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int counter = 1;
        public int Id { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public string Description { get; }
        public string Img { get; }

        public Product(string name, decimal cost, string description, string img)
        {
            Id = counter;
            Name = name;
            Cost = cost;
            Description = description;
            Img = img;

            counter++;
        }
    }
}
