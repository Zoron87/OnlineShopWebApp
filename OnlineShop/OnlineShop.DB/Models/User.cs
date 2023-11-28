using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineShop.DB.Models
{
    public class User : IdentityUser
    {
        public string Role { get; set; }
    }
}
