using Microsoft.AspNetCore.Identity;

namespace OnlineShop.DB.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string AvatarImagepath { get; set; }
    }
}
