using Microsoft.AspNetCore.Identity;
using OnlineShop.DB.Models;
using System.Collections.Generic;

namespace OnlineShop.DB
{
    public class IdentityInitializer
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            var adminEmail = "admin@example.com";
            var password = "Admin123456!";

            if (roleManager.FindByNameAsync(Constants.AdminRoleName).Result == null)
            {
                roleManager.CreateAsync(new UserRole(Constants.AdminRoleName, "Учетная запись, обладающая административными правами")).Wait();
            }

            if (roleManager.FindByNameAsync(Constants.UserRoleName).Result == null) 
            {
                roleManager.CreateAsync(new UserRole(Constants.UserRoleName, "Учетная запись обычного пользователя")).Wait();
            }

            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail, Role = Constants.AdminRoleName };
                var result = userManager.CreateAsync(admin, password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Constants.AdminRoleName).Wait();
                }
                else
                    throw new System.Exception("Дефолтный администратор не был добавлен!");
            }
        }
    }
}
