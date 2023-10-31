using System;

namespace OnlineShopWebApp.Models
{
    public class ShopUser
    {
        public Guid Id = Guid.NewGuid();
        public string Email { get; set; }
        public string Password { get; set; }

        public ShopUser() { }

        public ShopUser(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }
    }
}
