using Microsoft.AspNetCore.Identity;

namespace OnlineShop.DB.Models
{
    public class UserRole : IdentityRole
    {
        public UserRole() : base() { }
        public UserRole(string name, string description) : base(name)
        {
            this.Description = description;
        }
        public virtual string Description { get; set; }
    }
}