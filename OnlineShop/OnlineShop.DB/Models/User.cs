using Microsoft.AspNetCore.Identity;

namespace OnlineShop.DB.Models
{
    public class User : IdentityUser
    {
        public string Role { get; set; }
    }
}
