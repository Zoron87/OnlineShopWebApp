using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IUserStorage
    {
        void Add(Register register);
        void Remove(string Email);
        List<ShopUser> GetAll();
        bool CheckExistUser(Login loginInfo);
    }
}
