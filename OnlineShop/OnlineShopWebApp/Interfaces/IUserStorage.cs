using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IUserStorage
    {
        void Add(Register register);
        void Delete(string Email);
        List<UserViewModel> GetAll();
        bool CheckExistUser(Login loginInfo);
        UserViewModel TryGetByEmail(string Email);
        void Edit(UserViewModel shopUser);
    }
}
