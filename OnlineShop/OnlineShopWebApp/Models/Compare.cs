using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Compare
    {
        public int Id { get; }
        public Guid UserId { get; }
        public List<ProductViewModel> Products { get; set; }
        public Compare(Guid userId, List<ProductViewModel> products)
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
