using Newtonsoft.Json;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Providers;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
    public class UserStorageInJson : IUserStorage
    {
        private string filePath = "Storages/Users.json";
        private List<UserViewModel> users;
        public UserStorageInJson()
        {
            users = new List<UserViewModel>();
        }
        public void Add(Register register)
        {
            var users = GetAll();
            users.Add(new UserViewModel() { Email = register.Email, Password = register.Password });
            SaveAll(users);
        }

        public bool CheckExistUser(Login loginInfo)
        {
            var users = GetAll();
            return users.FirstOrDefault(u => u.Email == loginInfo.Email && u.Password == loginInfo.Password) != null;
        }

        public void Delete(string Email)
        {
            var users = GetAll();
            var user = users.FirstOrDefault(u => u.Email == Email);
            if (user != null) 
                users.Remove(user);
            SaveAll(users);
        }

        public UserViewModel TryGetByEmail(string Email)
        {
            var users = GetAll();
            var user = users.FirstOrDefault(u => u.Email == Email);
            user.CheckNullItem("Указанный пользователь не найден!");
            return user;
        }

        private void SaveAll(List<UserViewModel> users)
        {
            FileProvider.SaveInfo(filePath, JsonConvert.SerializeObject(users, Formatting.Indented));
        }

        public List<UserViewModel> GetAll()
        {
            var oldUsers = FileProvider.GetInfo(filePath);
            if (!string.IsNullOrEmpty(oldUsers))
                return JsonConvert.DeserializeObject<List<UserViewModel>>(oldUsers);
            return users;
        }

        public void Edit(UserViewModel shopUser)
        {
            var users = GetAll();
            var user = users.FirstOrDefault(u => u.Email == shopUser.Email);
            user.Name = shopUser.Name;
            user.Password = shopUser.Password;
            user.Role = shopUser.Role;
            SaveAll(users);
        }
    }
}
