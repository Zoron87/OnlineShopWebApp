using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Storages
{
    public class UserStorage : IUserStorage
    {
        private readonly List<User> userStorage = new List<User>();

        public User Login(User user)
        {
            var loginUser = userStorage.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            return loginUser != null ? loginUser : null;
        }

        public void Registration(User user)
        {
           if (userStorage.Any(u => u.Email == user.Email))
           {
                throw new Exception("Данная почта уже используется!");
           }

           var newUser = new User(user.Name, user.Email, user.Password);

           userStorage.Add(newUser);
        }

        public void Delete(Guid userId)
        {
            throw new NotImplementedException();
        }

        public User TryGetById(Guid userId)
        {
            return userStorage.FirstOrDefault(u => u.Id == userId);
        }
    }
}
