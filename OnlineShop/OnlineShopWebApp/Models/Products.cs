using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Threading;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int IdCounter = 1;

        public int Id { get; }
        private string Name { get; set; }
        private decimal Cost { get; set; }
        private string Description { get; set; }

        public Product(string name, decimal cost, string description)
        {
            Id = IdCounter;
            Name = name;
            Cost = cost;
            Description = description;

            Interlocked.Increment(ref IdCounter);
        }

        public override string ToString()
        {
            return $"{Id} \n{Name} \n{Cost}\n{Description}";
        }
    }
}
