using System;

namespace OnlineShop.DB.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string URL { get; set; }
        public Guid ProductId { get; set; }
    }
}
