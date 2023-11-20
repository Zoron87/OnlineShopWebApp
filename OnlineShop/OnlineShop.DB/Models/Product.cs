using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.DB.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
