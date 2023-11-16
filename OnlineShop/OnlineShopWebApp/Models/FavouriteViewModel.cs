using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class FavouriteViewModel
    {
        public int Id { get; }
        public Guid UserId { get; }
        public List<ProductViewModel> Products { get; set; }
        public FavouriteViewModel() { }
        public FavouriteViewModel(Guid userId, List<ProductViewModel> products)
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
