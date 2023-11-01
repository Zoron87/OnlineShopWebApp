using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IUserStorage
    {
        void Add(Register register);
        void Delete(string Email);
        List<ShopUser> GetAll();
        bool CheckExistUser(Login loginInfo);
        ShopUser TryGetByEmail(string Email);
        void Edit(ShopUser shopUser);
    }
}
