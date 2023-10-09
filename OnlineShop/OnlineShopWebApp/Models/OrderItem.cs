using System;

namespace OnlineShopWebApp.Models
{
    public class OrderItem
    {
        public int Id { get; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DeliveryType { get; set; }
        public string DeliveryDate { get; set;}
        public string DeliveryTime { get; set; }
        public string PayType { get; set; }
        public string Comment { get; set; }

        public OrderItem() { }

        public OrderItem(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
