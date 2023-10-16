using System;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public Guid Id;
        public string Name { get; }
        public string Email { get;}
        public string Password { get;}

        public User(string Name, string Email, string Password)
        {
            Guid Id = Guid.NewGuid();
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
        }
    }
}
