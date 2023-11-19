using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class CompareViewModel
    {
        public int Id { get; }
        public Guid UserId { get; }
        public List<ProductViewModel> Products { get; set; }
        public CompareViewModel(Guid userId, List<ProductViewModel> products)
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
