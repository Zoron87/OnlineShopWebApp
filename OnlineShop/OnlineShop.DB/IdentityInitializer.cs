﻿using Microsoft.AspNetCore.Identity;
using OnlineShop.DB.Models;
using System.Threading.Tasks;

namespace OnlineShop.DB
{
    public class IdentityInitializer
    {
        public async static Task Initialize(UserManager<User> userManager, RoleManager<UserRole> roleManager)
        {
            var adminEmail = "admin@example.com";
            var password = "Admin123456!";

            if (await roleManager.FindByNameAsync(Constants.AdminRoleName) == null)
            {
                await roleManager.CreateAsync(new UserRole(Constants.AdminRoleName, "Учетная запись, обладающая административными правами"));
            }

            if (await roleManager.FindByNameAsync(Constants.UserRoleName) == null) 
            {
                await roleManager.CreateAsync(new UserRole(Constants.UserRoleName, "Учетная запись обычного пользователя"));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail, Role = Constants.AdminRoleName };
                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, Constants.AdminRoleName);
                }
                else
                    throw new System.Exception("Дефолтный администратор не был добавлен!");
            }
        }
    }
}
