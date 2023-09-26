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
            return $"{Id}{Environment.NewLine}{Name}{Environment.NewLine}{Cost}{Environment.NewLine}{Description}";
        }
    }
}
