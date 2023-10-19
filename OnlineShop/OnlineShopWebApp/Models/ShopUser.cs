using System;

namespace OnlineShopWebApp.Models
{
    public static class ShopUser
    {
        public static Guid Id = Guid.NewGuid();
        public static string Name { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }
    }
}
