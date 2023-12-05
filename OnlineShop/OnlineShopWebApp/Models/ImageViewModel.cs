
using System;

namespace OnlineShopWebApp.Models
{
    public class ImageViewModel
    {
        public Guid Id { get; set; }
        public string URL { get; set; }
        public Guid ProductId { get; set; }
    }
}
