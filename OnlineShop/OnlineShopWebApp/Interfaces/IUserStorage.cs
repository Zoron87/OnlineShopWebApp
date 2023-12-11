using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Interfaces
{
    public interface IUserStorage
    {
        Task Add(Register register);
        Task Delete(string Email);
        Task<List<UserViewModel>> GetAll();
        Task<bool> CheckExistUser(Login loginInfo);
        UserViewModel TryGetByEmail(string Email);
        Task Edit(UserViewModel userViewModel);
    }
}
