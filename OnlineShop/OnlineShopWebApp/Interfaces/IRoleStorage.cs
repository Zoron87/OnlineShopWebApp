using OnlineShopWebApp.Areas.Administrator.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IRoleStorage
    {
        void Add(Role role);
        void Delete(string name);
        List<Role> GetAll();
        void SaveAll(List<Role> roles);
    }
}
