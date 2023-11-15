using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Favourite
    {
        public int Id { get; }
        public Guid UserId { get; }
        public List<ProductViewModel> Products { get; set; }
        public Favourite(Guid userId, List<ProductViewModel> products)
        {
            UserId = userId;
            Products = products;
        }
        public int Amount
        {
            get
            {
                return Products.Count;
            }
        }
    }
}
