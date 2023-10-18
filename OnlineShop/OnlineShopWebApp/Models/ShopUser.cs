using System;

namespace OnlineShopWebApp.Models
{
    public static class ShopUser
    {
        public static Guid Id = Guid.NewGuid();
        public static string Name { get; }
        public static string Email { get;}
        public static string Password { get;}
    }
}
