using System;

namespace OnlineShop.DB.Models
{
    public class ShopUser
    {
        public Guid Id = Guid.NewGuid();
        public string Email { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
