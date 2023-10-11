using System;

namespace OnlineShopWebApp.Models
{
    public class OrderDetails
    {
        public int Id { get; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public enum DeliveryType
        {
            Самовывоз,
            Курьер
        }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public enum PayType
        {
            Онлайн,
            Наличными
        }
        public string Comment { get; set; }
    }
}
