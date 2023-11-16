﻿using System;

namespace OnlineShopWebApp.Models
{
    public class CartItemViewModel
    {
        public Guid Id { get; }
        public ProductViewModel Product { get; }
        public int Quantity { get; set; }
        public CartItemViewModel(ProductViewModel product, int quantity = 1)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal Cost()
        {
            return Product.Cost * Quantity;
        }
    }
}
