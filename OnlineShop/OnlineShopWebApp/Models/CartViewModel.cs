using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartItemViewModel> Items { get; set; }

        public CartViewModel(Guid userId, List<CartItemViewModel> items)
        {
            UserId = userId;
            Items = items;
        }

        public decimal Amount
        {
            get
            {
                return Items.Sum(c => c.Quantity);
            }
        }

        public decimal Cost()
        {
            return Items.Sum(s => s.Product.Cost * s.Quantity);
        }
    }
}
