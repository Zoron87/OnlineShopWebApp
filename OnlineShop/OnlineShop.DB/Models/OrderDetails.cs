﻿using System;

namespace OnlineShop.DB.Models
{
    public class OrderDetails
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DeliveryType Delivery { get; set; }
        public DateTime DeliveryDate { get; set; }
        public PayType Pay { get; set; }
        public string Comment { get; set; }
    }
}
