using System;
using System.Collections.Generic;

namespace OnlineShop.DB.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public List<Product> Products { get; set; }
    }
}
