using System;

namespace OnlineShopWebApp.Models
{
    public class OrderDetails
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public enum DeliveryType { }
        public DateTime DeliveryDate { get; set; }
        public enum PayType { }
        public string Comment { get; set; }
    }
}
