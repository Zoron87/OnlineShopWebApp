using Newtonsoft.Json;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
    public class UserStorageInJson : IUserStorage
    {
        private string filePath = "Storages/Users.json";
        private List<ShopUser> users;
        public UserStorageInJson()
        {
            users = new List<ShopUser>();
        }
        public void Add(Register register)
        {
            users.Add(new ShopUser(register.Email, register.Password));
            SaveAll();
        }

        public bool CheckExistUser(Login loginInfo)
        {
            var users = GetAll();
            return users.FirstOrDefault(u => u.Email == loginInfo.Email && u.Password == loginInfo.Password) != null;
        }

        public void Remove(string Email)
        {
            var users = GetAll();
            var user = users.FirstOrDefault(u => u.Email == Email);
            users.Remove(user);
            SaveAll();
        }

        public void SaveAll()
        {
            Providers.FileProvider.SaveInfo(filePath, JsonConvert.SerializeObject(users, Formatting.Indented));
        }

        public List<ShopUser> GetAll()
        {
            var oldUsers = Providers.FileProvider.GetInfo(filePath);
            if (!string.IsNullOrEmpty(oldUsers))
                return JsonConvert.DeserializeObject<List<ShopUser>>(oldUsers);
            return users;
        }
    }
}
