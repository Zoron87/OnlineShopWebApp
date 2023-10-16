using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface IUserStorage
    {
        User TryGetById(Guid userId);
        User Login(User user);
        void Registration(User user);
        void Delete(Guid userId);
    }
}
